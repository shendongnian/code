    namespace ReadUnicode {
        using System;
        using System.Diagnostics;
        using System.IO;
     
        class Program {
            
            const string application = "WriteAndPresentUnicode.exe";
            
            static void Main(string[] args) {
                Process myProcess = new Process();
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(application);
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcessStartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8; // this is the most important part, to get correct myString, see below
                myProcess.StartInfo = myProcessStartInfo;
                myProcess.Start();
                StreamReader myStreamReader = myProcess.StandardOutput;
                string myString = myStreamReader.ReadToEnd();
                myProcess.WaitForExit();
                myProcess.Close();
                Console.InputEncoding = System.Text.Encoding.UTF8;
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine(myString);
                Console.WriteLine("Press any key...");
                Console.ReadKey(true);
            } //Main
    
        } //class Program
    
    } //namespace ReadUnicode
