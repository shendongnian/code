    using System;
    using System.IO;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (String filePath in Directory.GetFiles(@"C:\folderName\", "*.*", SearchOption.AllDirectories))
                {             
                    File.Move(filePath, filePath.Replace("abc_", ""));
                }
            }
        }
    }
