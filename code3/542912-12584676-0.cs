                Process process = new Process();
                process.StartInfo.FileName = @"C:\Program Files\Wireshark\tshark.exe";
                process.StartInfo.Arguments = string.Format(" -i " + _interfaceNumber + " -c " + int.MaxValue + " -w " + _pcapPath);
                process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
           process.Start();
                StreamReader myStreamReader = process.StandardOutput;
                // Read the standard output of the spawned process. 
                string myString = myStreamReader.ReadLine();
                Console.WriteLine(myString);
    
                process.WaitForExit();
                process.Close();
            }
