    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.DirectoryServices;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    
    namespace zielonka.co.uk.stackoverflow.com.samples.unique
    {
        class Program
        {
            public class info
            {
                public string name;
                public Guid uniqueID;
            }
            static void Main(string[] args)
            {
                List<string> FolderInfoList = Directory.GetDirectories("c:\\").ToList();
                List<info> uniqueFolders = new List<info>();
                foreach (var VARIABLE in FolderInfoList)
                {
                    uniqueFolders.Add(new info(){name = VARIABLE, uniqueID = new Guid()});
                }
                foreach (var uniqueFolder in uniqueFolders)
                {
                    Console.WriteLine(uniqueFolder.uniqueID+" "+uniqueFolder.name);
                }
            }
        }
    }
