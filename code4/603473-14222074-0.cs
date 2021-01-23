    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {    
        class Program
        {
            static void Main(string[] args)
            {
                Process process = new Process();
                process.StartInfo.FileName = "notepad";
                //process.StartInfo.Arguments = "filename.txt"
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
            } 
        }
    }
