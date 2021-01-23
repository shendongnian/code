    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                if (args.Length != 0)
                    new System.Threading.Thread( new System.Threading.ParameterizedThreadStart(handelexit)).Start(args[0]);
                // your code here
            }
    
            static void handelexit(object data)
            {
                int id = System.Convert.ToInt32(data.ToString());
    
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(id);
                while (!p.HasExited)
                    System.Threading.Thread.Sleep(100);
                System.Environment.Exit(0);
            }
        }
    }
