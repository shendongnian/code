    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.IO;
    
    namespace CuRLTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                //
                // Setup the process with the ProcessStartInfo class.
                //
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = @"C:\curl.exe"; // Specify exe name.
                start.Arguments = "http://curl.haxx.se";
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                //
                // Start the process.
                //
                using (Process process = Process.Start(start))
                {
                    //
                    // Read in all the text from the process with the StreamReader.
                    //
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.Write(result);
                        Console.ReadLine();
                    }
                }
    
            }
        }
    }
   
