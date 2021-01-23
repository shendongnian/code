    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length != 1)
                {
                    Console.WriteLine("Usage: CheckAllAtt <directoryName>");
                    return;
                }
                var files = Directory.GetFiles(args[0]);
                foreach (string fileName in files)
                {
                    FileAttributes att = File.GetAttributes(fileName);
                    DumpAttr(fileName, att);
                }
            }
            private static void DumpAttr(string fileName, FileAttributes att)
            {
                StringBuilder sb = new StringBuilder("File: " + fileName);
                if ((att & FileAttributes.Archive) == FileAttributes.Archive)
                    sb.Append(" Archive,");
                if ((att & FileAttributes.Compressed) == FileAttributes.Compressed)
                    sb.Append(" Compressed,");
                if ((att & FileAttributes.Device) == FileAttributes.Device)
                    sb.Append(" Device,");
                if ((att & FileAttributes.Directory) == FileAttributes.Directory)
                    sb.Append(" Directory,");
                if ((att & FileAttributes.Encrypted) == FileAttributes.Encrypted)
                    sb.Append(" Encrypted,");
                if ((att & FileAttributes.Hidden) == FileAttributes.Hidden)
                    sb.Append(" Hidden,");
                if ((att & FileAttributes.Normal) == FileAttributes.Normal)
                    sb.Append(" Normal,");
                if ((att & FileAttributes.NotContentIndexed) == FileAttributes.NotContentIndexed)
                    sb.Append(" Normal,");
                if ((att & FileAttributes.Offline) == FileAttributes.Offline)
                    sb.Append(" Offline,");
                if ((att & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    sb.Append(" ReadOnly,");
                if ((att & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
                    sb.Append(" ReparsePoint,");
                if ((att & FileAttributes.SparseFile) == FileAttributes.SparseFile)
                    sb.Append(" SparseFile,");
                if ((att & FileAttributes.System) == FileAttributes.System)
                    sb.Append(" System,");
                if ((att & FileAttributes.Temporary) == FileAttributes.Temporary)
                    sb.Append(" Temporary,");
    
                sb.Length -= 1;
                Console.WriteLine(sb.ToString());
            }
        }
    }
