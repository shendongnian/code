    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        private TextBox CreateTextBox(string name, Point location)
        {
            TextBox textBox = new TextBox { Name = name, Location = location };
            textBox.Leave += textBox_Leave;
            textBox.Enter += textBox_Enter;
            return textBox;
        }
    
        private readonly Dictionary<string, string> TextBoxEnterText = new Dictionary<string, string>
        {
            { "T1", "Enter T1" },
            { "T2", "Enter T2" },
            { "T3", "Enter T3" },
            { "T4", "Enter T4" },
            { "T5", "Enter T5" },
        };
    
        private readonly Dictionary<string, string> TextBoxLeaveText = new Dictionary<string, string>
        {
            { "T1", "Leave T1" },
            { "T2", "Leave T2" },
            { "T3", "Leave T3" },
            { "T4", "Leave T4" },
            { "T5", "Leave T5" },
        };
    
        public Form1 ()
    	{
            Controls.Add(CreateTextBox("T1", new Point(10, 10)));
            Controls.Add(CreateTextBox("T2", new Point(10, 40)));
            Controls.Add(CreateTextBox("T3", new Point(10, 70)));
            Controls.Add(CreateTextBox("T4", new Point(10, 100)));
            Controls.Add(CreateTextBox("T5", new Point(10, 130)));
        }
    
        void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = TextBoxLeaveText[textBox.Name];
        }
    
        void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = TextBoxEnterText[textBox.Name];
        }
    }
