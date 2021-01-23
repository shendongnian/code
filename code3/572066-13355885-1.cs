    $t = @"
    using System;
    using System.Diagnostics;
    using System.IO;
    
     public  class Program
        {
            public static void Main()
            {    
                var processList = Process.GetProcessesByName("taskmgr");    
                foreach (var process in processList)
                {    
                    string myPath = "C:/"; //change data path as needed    
                    FileStream logfile;
                    //log program process
                    logfile = new FileStream(myPath + "/logfile.txt", FileMode.Append, FileAccess.Write);    
                    TextWriter oldLog = Console.Out;    
                    StreamWriter writelog;
                    writelog = new StreamWriter(logfile);
                        DateTime time = DateTime.Now;
                    string format = "MMM ddd d HH:mm yyyy";    
                    Console.SetOut(writelog);
                        // print out the process id
                    Console.WriteLine("Process Id=" + process.Id + " - " + time.ToString(format));    
                    Console.SetOut(oldLog);    
                    writelog.Close();    
                    //System.Environment.Exit(0); removed, otherwise closes the console                }
            }
        }
    "@
    Add-Type -TypeDefinition $t
    [program]::main()
