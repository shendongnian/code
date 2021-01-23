    using System;
    using System.IO;
    using System.Text;
    
    namespace CheckErrorWarning
    {
        class Program
        {
            // Pass on the command line the full path to the directory with the txt files
            static void Main(string[] args)
            {
                if (args.Length < 1)
                {
                    Console.WriteLine("Usage: CheckErrorWarning <directoryname>");
                    return;
                }
                if (Directory.Exists(args[0]) == false)
                {
                    Console.WriteLine("Directory : " + args[0] +" not found or not accessible");
                    return;
                }
                string[] textFiles = Directory.GetFiles(args[0], "*.txt");
                foreach (string fileName in textFiles)
                {
                    string[] lines = File.ReadAllLines(fileName);
                    for (int x = 0; x < lines.Length; x++)
                    {
                        int warnPos = lines[x].IndexOf("warning",
                                      StringComparison.CurrentCultureIgnoreCase);
                        if (warnPos > 0) Console.WriteLine("File:" + fileName + 
                                         ", warning at line " + x + 
                                         ", position " + warnPos);
                        int errPos = lines[x].IndexOf("error", 
                                     StringComparison.CurrentCultureIgnoreCase);
                        if (errPos > 0) Console.WriteLine("File:" + fileName + 
                                        ", error at line " + x + 
                                        ", position " + errPos);
                    }
                }
            }
        }
    }
