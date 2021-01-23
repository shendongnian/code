        void Main()
        {
        	System.Diagnostics.Process proc = new System.Diagnostics.Process();
        						proc.EnableRaisingEvents=true;
    // Program
        						proc.StartInfo.FileName="cmd.exe";
    // Arguments
        						proc.StartInfo.Arguments = "/c ping 127.0.0.1";
        						
        						// Set UseShellExecute to false for redirection.
        			proc.StartInfo.UseShellExecute = false;
        			
        			// Set our event handler to asynchronously read the sort output.
        			proc.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
        
        			// Redirect the standard output of the sort command.  
        			// This stream is read asynchronously using an event handler.
        			proc.StartInfo.RedirectStandardOutput = true;	
        						
        			proc.Start();								
        						
        			// Start the asynchronous read of the sort output stream.
        			proc.BeginOutputReadLine();						
        												
        			proc.WaitForExit();								
        			proc.Close();
        }
        
        private void SortOutputHandler(object sendingProcess, 
        			DataReceivedEventArgs outLine)
        		{
        			if (!String.IsNullOrEmpty(outLine.Data))
        			{
        			 // Do what You need with out
        			 Console.WriteLine(outLine.Data);
        			}
        		}
