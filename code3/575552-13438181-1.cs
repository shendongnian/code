    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static StreamReader reader;
    
            static void Main(string[] args)
            {
                Process cmd = new Process();
    
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.UseShellExecute = false;
    
                cmd.Start();
    
                reader = cmd.StandardOutput;
                StreamWriter writer = cmd.StandardInput;
    
    
                Thread t = new Thread(new ThreadStart(writingThread));
    
                t.Start();
    
                //Just write everything we type to the cmd.exe process
                while (true) writer.Write((char)Console.Read());
    
            }
    
            public static void writingThread()
            {
                //Just write everything cmd.exe writes back to our console
                while (true) Console.Write((char)reader.Read());
            }
        }
    }
