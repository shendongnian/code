    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
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
    
        private static readonly Dictionary<string, string> TextBoxEnterText = new Dictionary<string, string>
        {
            { "T1", "Enter T1" },
            { "T2", "Enter T2" },
            { "T3", "Enter T3" },
            { "T4", "Enter T4" },
            { "T5", "Enter T5" },
        };
    
        private static readonly Dictionary<string, string> TextBoxLeaveText = new Dictionary<string, string>
        {
            { "T1", "Leave T1" },
            { "T2", "Leave T2" },
            { "T3", "Leave T3" },
            { "T4", "Leave T4" },
            { "T5", "Leave T5" },
        };
    
        private void InitializeControls()
        {
            Controls.Add(new TextBox { Name = "T1", Location = new Point(10, 10) });
            Controls.Add(new TextBox { Name = "T2", Location = new Point(10, 40) });
            Controls.Add(new TextBox { Name = "T3", Location = new Point(10, 70) });
            Controls.Add(new TextBox { Name = "T4", Location = new Point(10, 100) });
            Controls.Add(new TextBox { Name = "T5", Location = new Point(10, 130) });
        }
    
        public Form1()
        {
            InitializeControls();
    
            foreach (string name in TextBoxEnterText.Keys)
                Controls.Find(name, true).First().Enter += textBox_Enter;
            foreach (string name in TextBoxLeaveText.Keys)
                Controls.Find(name, true).First().Leave += textBox_Leave;
        }
    
        static void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = TextBoxLeaveText[textBox.Name];
        }
    
        static void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = TextBoxEnterText[textBox.Name];
        }
    }
