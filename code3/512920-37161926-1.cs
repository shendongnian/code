    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                run_cmd();
            }
            private void run_cmd()
            {
                string fileName = @"C:\sample_script.py";
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(@"C:\Python27\python.exe", fileName)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }
    }
