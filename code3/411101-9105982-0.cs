    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
                string EV_HOME = @"C:\myprogram\leanrning\anotherfolder\";
                string parentFolder = new System.IO.DirectoryInfo(EV_HOME).Parent.FullName;
                string myFilePath = parentFolder + "\\MyFolder\\MySubFolder";
                Console.WriteLine(myFilePath);
            }
        }
    }
