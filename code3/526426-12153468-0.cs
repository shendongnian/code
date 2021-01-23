    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PostSharp.Aspects;
    using System.Diagnostics;
    using System.IO;
    
    namespace TestCode
    {
        public class Program
        {
            public static StreamReader ServerReader;
    
            public static StreamWriter ServerWriter;
    
            static void Main(string[] args)
            {
                // here are all information to start your mini server
                ProcessStartInfo startServerInformation = new ProcessStartInfo(@"c:\path\to\serverApp.exe");
    
                // this value put the server process invisible. put it to false in while debuging to see what happen
                startServerInformation.CreateNoWindow = true;
    
                // this avoid you problem
                startServerInformation.ErrorDialog = false;
    
                // this tells that you whant to get all connections from the server
                startServerInformation.RedirectStandardInput = true;
                startServerInformation.RedirectStandardOutput = true;
    
                // this tells that you whant to be able to use special caracter that are not define in ASCII like "é" or "ï"
                startServerInformation.StandardErrorEncoding = Encoding.UTF8;
                startServerInformation.StandardOutputEncoding = Encoding.UTF8;
    
                // start the server app here
                Process serverProcess = Process.Start(startServerInformation);
    
                // get the control of the output and input connection
                Program.ServerReader = serverProcess.StandardOutput;
                Program.ServerWriter = serverProcess.StandardInput;
    
                // write information to the server
                Program.ServerWriter.WriteLine("Hi server im the client app :D");
    
                // wait the server responce
                string serverResponce = Program.ServerReader.ReadLine();
    
                // close the server application if needed
                serverProcess.Kill();
            }
        }
    }
