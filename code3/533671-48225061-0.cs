    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Directory_List
    {
    
        public partial class Form1 : Form
        {
            public string MyPath = "";
            public string MyFileName = "";
            public string str = "";
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void cmdQuit_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
    
            private void cmdGetDirectory_Click(object sender, EventArgs e)
            {
                folderBrowserDialog1.ShowDialog();
                MyPath = folderBrowserDialog1.SelectedPath;
    
                saveFileDialog1.ShowDialog();
                MyFileName = saveFileDialog1.FileName;
    
                str = "Folder = " + MyPath + "\r\n\r\n\r\n";
    
                DirectorySearch(MyPath);
    
                var result = MessageBox.Show("Directory saved to Disk!", "", MessageBoxButtons.OK);
    
                Application.Exit();
    
            }
    
            public void DirectorySearch(string dir)
            {
    
                try
                {
                    foreach (string f in Directory.GetFiles(dir))
                    {
                        str = str + dir + "\\" + (Path.GetFileName(f)) + "\r\n";
                    }
    
    
                    foreach (string d in Directory.GetDirectories(dir, "*"))
                    {
                        
                        DirectorySearch(d);
                    }
    
                        System.IO.File.WriteAllText(MyFileName, str);
    
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
