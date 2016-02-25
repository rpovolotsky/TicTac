using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrestikiNoliki
{
    public partial class Form1 : Form
    {
        private int h = 0;
        private string name1, name2;
        private int name1Win=0, name1Game=1, name2Win=0, name2Game=0;
        private bool flag = false;

        public Form1()
        {
            InitializeComponent();
            lHod.Text = string.Empty;
#if DEBUG
            h = 4;
            name2 = "qwe";
            name1 = "qwe1";
            CreateGame();
#endif

        }

        Button CreateNode()
        {
            Button btn = new Button();
            btn.Dock = System.Windows.Forms.DockStyle.Fill;
            btn.Location = new System.Drawing.Point(3, 3);
            btn.Click += new System.EventHandler(this.btnHod);
            btn.ImageList = imButtonIcons;
            return btn;
        }

        bool ChekStatus()
        {
            bool flag2 = true;
            
            //По столбцам
            for (int i = 0; i < h; i++)
            {
                flag2 = true;
                Button item0 = tlpPole.Controls[i * h] as Button;
                int indexImageItem0 = item0.ImageIndex;
                if(indexImageItem0==-1)continue;
                for (int j = 1; j < h&&flag2; j++)
                {
                    
                    Button item = tlpPole.Controls[i*h + j] as Button;
                    
                    int imageIndexItem = item.ImageIndex;
                    if (imageIndexItem != indexImageItem0)
                    {
                        flag2 = false;
                    }

                }
                if (flag2)
                {
                    string message = "Выиграл ";
                    if (indexImageItem0 == 0)
                    {
                        name2Win += 1;
                        message += name2 + " !" + (((float)name2Win / (float)name2Game) * 100).ToString() + "%выигрыша!";
                        StreamWriter sw = new StreamWriter(Application.ExecutablePath + name2 + ".txt", true);
                        sw.WriteLine(true);
                        StreamWriter sw1 = new StreamWriter(Application.ExecutablePath + name1 + ".txt", true);
                        sw1.WriteLine(false);
                        sw.Close();
                        sw1.Close();

                    }
                    else
                    {
                        name1Win += 1;
                        message += name1 + " !" + (((float)name1Win / (float)name1Game) * 100).ToString() + "%выигрыша!";
                        StreamWriter sw = new StreamWriter(Application.ExecutablePath + name2 + ".txt", true);
                        sw.WriteLine(false);
                        StreamWriter sw1 = new StreamWriter(Application.ExecutablePath + name1 + ".txt", true);
                        sw1.WriteLine(true);
                        sw.Close();
                        sw1.Close();
                    }
                    foreach (var control in tlpPole.Controls)
                    {
                        Button item = control as Button;
                        item.Enabled = false;
                    }
                    MessageBox.Show(message, "Поздравляем!");
                    return true;
                }
            }
            
            //По строкам
            for (int j = 0; j < h; j++)
            {
                flag2 = true;
                Button item0 = tlpPole.Controls[j] as Button;
                int indexImageItem0 = item0.ImageIndex;
                if (indexImageItem0 == -1) continue;
                for (int i = 1; i < h && flag2; i++)
                {

                    Button item = tlpPole.Controls[i * h + j] as Button;

                    int imageIndexItem = item.ImageIndex;
                    if (imageIndexItem != indexImageItem0)
                    {
                        flag2 = false;
                    }

                }
                if (flag2)
                {
                    string message = "Выиграл ";
                    if (indexImageItem0 == 0)
                    {
                        name2Win+=1;
                        message += name2 + " !" + (((float)name2Win / (float)name2Game) * 100).ToString() + "%выигрыша!";
                        StreamWriter sw = new StreamWriter(Application.ExecutablePath + name2 + ".txt", true);
                        sw.WriteLine(true);
                        StreamWriter sw1 = new StreamWriter(Application.ExecutablePath + name1 + ".txt", true);
                        sw1.WriteLine(false);
                        sw.Close();
                        sw1.Close();

                    }
                    else
                    {
                        name1Win+=1;
                        message += name1 + " !" + (((float)name1Win / (float)name1Game) * 100).ToString() + "%выигрыша!";
                        StreamWriter sw = new StreamWriter(Application.ExecutablePath + name2 + ".txt", true);
                        sw.WriteLine(false);
                        StreamWriter sw1 = new StreamWriter(Application.ExecutablePath + name1 + ".txt", true);
                        sw1.WriteLine(true);
                        sw.Close();
                        sw1.Close();
                    }
                    foreach (var control in tlpPole.Controls)
                    {
                        Button item = control as Button;
                        item.Enabled = false;
                    }
                    MessageBox.Show(message, "Поздравляем!");
                    return true;
                }
            }
            //По главной диагонали
            
            flag2 = true;
            Button item00 = tlpPole.Controls[0] as Button;
            int indexImageItem00 = item00.ImageIndex;
            if (indexImageItem00 == -1) flag2 = false;
            for (int i = 0; i < h && flag2; i++)
            {
                Button item = tlpPole.Controls[i * h + i] as Button;

                int imageIndexItem = item.ImageIndex;
                if (imageIndexItem != indexImageItem00)
                {
                    flag2 = false;
                }
            }
            if (flag2)
            {
                string message = "Выиграл ";
                if (indexImageItem00 == 0)
                {
                    name2Win += 1;
                    message += name2 + " !" + (((float)name2Win / (float)name2Game) * 100).ToString() + "%выигрыша!";
                    StreamWriter sw = new StreamWriter(Application.ExecutablePath + name2 + ".txt", true);
                    sw.WriteLine(true);
                    StreamWriter sw1 = new StreamWriter(Application.ExecutablePath + name1 + ".txt", true);
                    sw1.WriteLine(false);
                    sw.Close();
                    sw1.Close();

                }
                else
                {
                    name1Win += 1;
                    message += name1 + " !" + (((float)name1Win / (float)name1Game) * 100).ToString() + "%выигрыша!";
                    StreamWriter sw = new StreamWriter(Application.ExecutablePath + name2 + ".txt", true);
                    sw.WriteLine(false);
                    StreamWriter sw1 = new StreamWriter(Application.ExecutablePath + name1 + ".txt", true);
                    sw1.WriteLine(true);
                    sw.Close();
                    sw1.Close();
                }
                foreach (var control in tlpPole.Controls)
                {
                    Button item = control as Button;
                    item.Enabled = false;
                }
                MessageBox.Show(message, "Поздравляем!");
                return true;
            }
            //По побочной диагонали
            flag2 = true;
            Button itemh0 = tlpPole.Controls[h*(h-1)] as Button;
            int indexImageItemh0 = itemh0.ImageIndex;
            if (indexImageItemh0 == -1) flag2 = false;
            for (int i = 1; i < h && flag2; i++)
            {
                Button item = tlpPole.Controls[(h-1-i) * h + i] as Button;

                int imageIndexItem = item.ImageIndex;
                if (imageIndexItem != indexImageItemh0)
                {
                    flag2 = false;
                }
            }
            if (flag2)
            {
                string message = "Выиграл ";
                if (indexImageItemh0 == 0)
                {
                    name2Win += 1;
                    message += name2 + " !" + (((float)name2Win / (float)name2Game) * 100).ToString() + "%выигрыша!";
                    StreamWriter sw = new StreamWriter(Application.ExecutablePath + name2 + ".txt", true);
                    sw.WriteLine(true);
                    StreamWriter sw1 = new StreamWriter(Application.ExecutablePath + name1 + ".txt", true);
                    sw1.WriteLine(false);
                    sw.Close();
                    sw1.Close();

                }
                else
                {
                    name1Win += 1;
                    message += name1 + " !" + (((float)name1Win / (float)name1Game) * 100).ToString() + "%выигрыша!";
                    StreamWriter sw = new StreamWriter(Application.ExecutablePath + name2 + ".txt", true);
                    sw.WriteLine(false);
                    StreamWriter sw1 = new StreamWriter(Application.ExecutablePath + name1 + ".txt", true);
                    sw1.WriteLine(true);
                    sw.Close();
                    sw1.Close();
                }
                foreach (var control in tlpPole.Controls)
                {
                    Button item = control as Button;
                    item.Enabled = false;
                }
                MessageBox.Show(message, "Поздравляем!");
                return true;
            }
            //Ничья
            bool flag3 = true;
            foreach (var control in tlpPole.Controls)
            {
                Button item = control as Button;
                if (item.Enabled) flag3 = false;
            }
            if (flag3)
            {
                MessageBox.Show("Ничья!");
                return true;
                StreamWriter sw = new StreamWriter(Application.ExecutablePath + name2 + ".txt",true);
                sw.WriteLine(false);
                
                StreamWriter sw1 = new StreamWriter(Application.ExecutablePath + name1 + ".txt",true);
                sw1.WriteLine(false);
                sw.Close();
                sw1.Close();
            }
            return false;
        }
        private void btnHod(object sender, EventArgs e)
        {
            Button selectButton = sender as Button;
            if (flag)
            {
                
                selectButton.ImageIndex = 0; 
            }
            else
            {
                selectButton.ImageIndex = 1; 
            }
            flag = !flag;
            selectButton.Enabled = false;
            ChekStatus();
            if (flag)
            {
                lHod.Text = "Сейчас ходит " + name2;

            }
            else
            {
                lHod.Text = "Сейчас ходит " + name1;
            }

        }

        private void CreateGame()
        {
            flag = false;
            tlpPole.Controls.Clear();
            tlpPole.ColumnStyles.Clear();
            tlpPole.RowStyles.Clear();
            tlpPole.ColumnCount = h;
            tlpPole.RowCount = h;
            float hR = 100/h;
            for (int i = 0; i < h; i++)
            {
                tlpPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, hR));
                tlpPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    tlpPole.Controls.Add(CreateNode(),i,j);
                }
            }



            lHod.Text = "Сейчас ходит " + name1;
        }

        private void ChekNames()
        {
            if (File.Exists(Application.ExecutablePath + name1 + ".txt"))
            {
                StreamReader sr = new StreamReader(Application.ExecutablePath + name1 + ".txt");
                List<bool> listWins = new List<bool>();
                while (!sr.EndOfStream)
                {
                   listWins.Add(bool.Parse(sr.ReadLine()));
                    if (listWins.Last())
                    {
                        name1Win++;
                    }
                    
                }
                name1Game = listWins.Count+1;
                sr.Close();
            }
            else
            {
                File.Create(Application.ExecutablePath + name1 + ".txt").Close();
            }
            if (File.Exists(Application.ExecutablePath + name2 + ".txt"))
            {
                StreamReader sr = new StreamReader(Application.ExecutablePath + name2 + ".txt");
                List<bool> listWins = new List<bool>();
                while (!sr.EndOfStream)
                {
                    listWins.Add(bool.Parse(sr.ReadLine()));
                    if (listWins.Last())
                    {
                        name2Win++;
                    }
                }
                name2Game = listWins.Count+1;
                sr.Close();
            }
            else
            {
                File.Create(Application.ExecutablePath + name2 + ".txt").Close();
            }

        }
        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            metka1:
            btnSave.Enabled = true;
            string temp = Microsoft.VisualBasic.Interaction.InputBox("Введите размер матрицы для игры");
            try
            {
                h = int.Parse(temp);
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели некорректное значение стороны квадрата оно должно быть целым числом");
                goto metka1;
            }
            if (h < 3 || h > 10)
            {
                MessageBox.Show("Размер поля может быть от 3 до 10!");
                goto metka1;
            }
            name1 = Microsoft.VisualBasic.Interaction.InputBox("Введите имя первого игрока");
            metka2:
            name2 = Microsoft.VisualBasic.Interaction.InputBox("Введите имя второго игрока");
            if (name1.ToLower().Equals(name2.ToLower()))
            {
                MessageBox.Show("Имена игроков должны различаться!");
                goto metka2;
            }
            //Назначение 
            metka3:
            Random rd = new Random();
            int one = rd.Next(0, 100), two = rd.Next(0, 100), idea = rd.Next(0, 100);
            if (Math.Abs(idea - one) == Math.Abs(idea - two)) { goto metka3; }
            if (Math.Abs(idea - one) > Math.Abs(idea - two))
            {
                string tempname = name2;
                name2 = name1;
                name1 = tempname;
            }
            ChekNames();
            CreateGame();
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "txt";
            dialog.FileName = "Game1.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(dialog.FileName);
                sw.WriteLine(h);
                sw.WriteLine(name1);
                sw.WriteLine(name2);
                foreach (Control control in tlpPole.Controls)
                {
                    Button btn = control as Button;
                    sw.WriteLine(btn.ImageIndex);
                }
                sw.WriteLine(flag);
                sw.Close();
            }
            

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text File|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(dialog.FileName);
                    h = int.Parse(sr.ReadLine());
                    name1 = sr.ReadLine();
                    name2 = sr.ReadLine();
                    CreateGame();
                    ChekNames();
                    foreach (Control control in tlpPole.Controls)
                    {
                        Button btn = control as Button;
                        btn.ImageIndex = int.Parse(sr.ReadLine());
                        if (btn.ImageIndex != -1)
                        {
                            btn.Enabled = false;
                        }
                    }
                    flag = bool.Parse(sr.ReadLine());
                    sr.Close();
                    btnSave.Enabled = true;
                }
                catch (Exception)
                {

                    MessageBox.Show("Произошла ошибка при загрузке файла!");
                }
            }
        }
    }
}
