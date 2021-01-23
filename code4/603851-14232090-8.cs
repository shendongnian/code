    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            Button[,] btn = new Button[8, 8];
            public Form1()
            {
                InitializeComponent();
                for (int x = 0; x < btn.GetLength(0); x++)
                {
                    for (int y = 0; y < btn.GetLength(1); y++)
                    {
                        btn[x, y] = new Button();
                        btn[x, y].SetBounds((50 * x) + 30, (50 * y) + 30, 40, 40);
                        btn[x, y].Click += new EventHandler(this.btnEvent_click);
                        Controls.Add(btn[x, y]);
                        btn[x, y].BackColor = Color.Black;
                    }
                }
    
                this.FormClosing += new FormClosingEventHandler(this.SaveEventHandler);
                LoadFromFile();
            }
    
            void btnEvent_click(object sender, EventArgs e)
            {
                Control ctrl = ((Control)sender);
                switch (ctrl.BackColor.Name)
                {
                    case "Red":
                        ctrl.BackColor = Color.Green;
                        break;
                    case "Black":
                        ctrl.BackColor = Color.Red;
                        break;
                    case "Green":
                        ctrl.BackColor = Color.Yellow;
                        break;
                    case "Yellow":
                        ctrl.BackColor = Color.Black;
                        break;
                    default:
                        ctrl.BackColor = Color.Black;
                        break;
                }
            }
    
            void SaveEventHandler(object sender, EventArgs e)
            {
                SaveToFile();
            }
    
            private const string filePath = @"d:\test.txt";
            private void LoadFromFile()
            {
                if (!System.IO.File.Exists(filePath))
                    return;
    
                byte[] data = System.IO.File.ReadAllBytes(filePath);
                if (data == null || data.Length != btn.GetLength(0) * btn.GetLength(1))
                    return;
    
                for (int x = 0; x < btn.GetLength(0); x++)
                {
                    for (int y = 0; y < btn.GetLength(1); y++)
                    {
                        int position = (y * btn.GetLength(0) + x);
    
                        char value = (char)data[position];
                        Color color;
                        switch (value)
                        {
                            case '1':
                                color = Color.Red;
                                break;
                            case '0':
                                color = Color.Black;
                                break;
                            case '2':
                                color = Color.Green;
                                break;
                            case '3':
                                color = Color.Yellow;
                                break;
                            default:
                                color = Color.Black;
                                break;
                        }
    
                        btn[x, y].BackColor = color;
                    }
                }
            }
    
            private void SaveToFile()
            {
                byte[] data = new byte[btn.GetLength(0) * btn.GetLength(1)]; 
                for (int x = 0; x < btn.GetLength(0); x++)
                {
                    for (int y = 0; y < btn.GetLength(1); y++)
                    {
                        int position = (y * btn.GetLength(0) + x);
                        char value;
                        switch (btn[x, y].BackColor.Name)
                        {
                            case "Red":
                                value = '1';
                                break;
                            case "Black":
                                value = '0';
                                break;
                            case "Green":
                                value = '2';
                                break;
                            case "Yellow":
                                value = '3';
                                break;
                            default:
                                value = '0';
                                break;
                        }
                        data[position] = (byte)value;
                    }
                }
    
                System.IO.File.WriteAllBytes(filePath, data);
            }
        }
    }
