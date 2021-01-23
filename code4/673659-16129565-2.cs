    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Remove_String_from_Text_Box_from_back
    {
        public partial class Form1 : Form
        {
     private void selectLastToken(string str0)
            {
                Regex regex = new Regex(@"([\d()]*;)$");
                var capturedGroups = regex.Match(str0);
    
                int idx0 = 0;
                if (capturedGroups.Captures.Count > 0)
                {
                    idx0 = str0.IndexOf(capturedGroups.Captures[0].Value, 0);
                    textBox1.Select(idx0, textBox1.Text.Length);
                }
            }
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                textBox1.Text = "(205)33344455;918845566778;";
                textBox1.Select(0, 0);
            }
           
            //selects last token terminated by ;
            private void selectTextOnBackSpace()
            {
                string str0 = textBox1.Text;
                int idx0 = str0.LastIndexOf(';');
                if (idx0<0)
                {
                    idx0 = 0;
                }
                string str1 = str0.Remove(idx0);
                int idx1 = str1.LastIndexOf(';');
                if (idx1 < 0)
                {
                    idx1 = 0;
                }
                else
                {
                    idx1 += 1;
                }
                textBox1.SelectionStart = idx1;
                textBox1.SelectionLength = str0.Length - idx1;
            }
    
          
            private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Back )
                {
                    if (textBox1.SelectionLength==0)
                    {
                        selectTextOnBackSpace();
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
        }
    }
