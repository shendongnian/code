    using System;
    using System.IO;
    
    namespace getLastTimeStamp
    {
        class Program
        {
            static void Main(string[] args)
            {
                FileInfo info = new FileInfo(@"C:\temp\getLastTimeStamp\Program.cs");
    
                Console.WriteLine(info.CreationTime.ToString());
                Console.WriteLine(info.LastWriteTime.ToString());
    
                Console.ReadLine();
            }
        }
    }
