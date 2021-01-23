            //Set output of program to be written to process output stream
            pProcess.StartInfo.RedirectStandardError = true;
            pProcess.StartInfo.RedirectStandardOutput = true;
            //Start the process
            pProcess.Start();
            //Wait for process to finish
            pProcess.WaitForExit();
            //Get program output
            string strError = pProcess.StandardError.ReadToEnd();
            string strOutput = pProcess.StandardOutput.ReadToEnd();
