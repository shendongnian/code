    using System;
    using System.Text;
    using System.DirectoryServices;
    namespace RevertToParentHandlerMappings
    {
        class Program
        {
            static void Main(string[] args)
            {
                string vDirPath = "IIS://localhost/W3SVC/1/ROOT/AppName";
                DirectoryEntry vDir = new DirectoryEntry(vDirPath);
            
                vDir.Properties["ScriptMaps"].Clear();
            
                vDir.CommitChanges();
            }
        }
    }
