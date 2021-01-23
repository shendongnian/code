    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace TextBoxLines
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public List<string> PtagName = new List<string>();
    
            private void textBox1_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (textBox1.SelectedText.Length > 0)
                    {
                        string[] lines = textBox1.SelectedText.Split('\n');
                        foreach (var line in lines)
                        {
                            PtagName.Add(line);
                        }
                    }
                    foreach (var line in PtagName)
                        MessageBox.Show(line);
    
                    PtagName.Clear();
                }
            }
        }
    }
