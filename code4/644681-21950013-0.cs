    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace DeleteWord
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                // Tab, space, line feed
                char[] whitespace = {'\x09', '\x20', '\xA0'};
                string text = textBox1.Text;
                int start = textBox1.SelectionStart;
    
                if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) && textBox1.SelectionLength > 0)
                {
                    e.SuppressKeyPress = true;
                    textBox1.Text = text.Substring(0, start) + text.Substring(start + textBox1.SelectionLength);
                    textBox1.SelectionStart = start;
                    return;
                }
    
                else if (e.KeyCode == Keys.Back && e.Control)
                {
                    e.SuppressKeyPress = true;
    
                    if (start == 0) return;
    
                    int pos = Math.Max(text.LastIndexOfAny(whitespace, start - 1), 0);
                    
                    while (pos > 0)
                    {
                        if (!whitespace.Contains(text[pos]))
                        {
                            pos++;
                            break;
                        }
                        pos--;
                    }
                    
                    textBox1.Text = text.Substring(0, pos) + text.Substring(start);
                    textBox1.SelectionStart = pos;
                }
                else if (e.KeyCode == Keys.Delete && e.Control)
                {
                    e.SuppressKeyPress = true;
    
                    int last = text.Length - 1;
    
                    int pos = text.IndexOfAny(whitespace, start);
                    if (pos == -1) pos = last + 1;
    
                    while (pos <= last)
                    {
                        if (!whitespace.Contains(text[pos])) break;
                        pos++;
                    }
    
                    textBox1.Text = text.Substring(0, start) + text.Substring(pos);
                    textBox1.SelectionStart = start;
                }
            }
    
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if (keyData == Keys.Tab)
                {
                    textBox1.Paste("\t");
                    return true;
                }
                else if (keyData == (Keys.Shift | Keys.Tab))
                {
                    textBox1.Paste("\xA0");
                    return true;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
    
        }
    }
