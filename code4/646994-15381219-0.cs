    using System;
    using System.Windows.Forms;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                Console.Write(ofd.FileName);
            }
        }
    }
