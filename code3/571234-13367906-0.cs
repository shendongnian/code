    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public static class Environment
            {
            }
            public Form1()
            {
                InitializeComponent();
            }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = System.Environment.GetCommandLineArgs();
            string filePath = args[0];
            for (int i = 0; i <= args.Length - 1; i++)
            {
                if (args[i].EndsWith(".exe") == false)
                {
                    textBox1.Text = System.IO.File.ReadAllText(args[i],
                    Encoding.Default);
                }
            }
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string[] args = System.Environment.GetCommandLineArgs();
            string filePath = args[0];
        }
        
    }
    public sealed class StartupEventArgs : EventArgs
    {
    }
    }
