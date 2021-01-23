    void Main()
    {
    	System.Diagnostics.Process proc = new System.Diagnostics.Process();						
    						proc.StartInfo.FileName="cmd.exe";
    						proc.StartInfo.Arguments = "/c ping 127.0.0.1";
    						proc.StartInfo.UseShellExecute = false;
    						proc.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
    						proc.StartInfo.RedirectStandardOutput = true;	
    						proc.Start();								
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
