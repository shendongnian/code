    using System.Diagnostics;   //at the top of your class
 
    Process[] processlist = Process.GetProcesses();
    foreach(Process theprocess in processlist){
    Console.WriteLine(“Process: {0} ID: {1}”, theprocess.ProcessName, theprocess.Id);
    }
