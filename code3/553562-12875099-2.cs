        using System;
        using System.IO;
        using System.Windows.Forms;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                    Console.WriteLine(appDirectory);
                }
            }
        }
