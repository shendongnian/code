    private static void ProcessOutputCharacters(StreamReader streamReader)
    {
        int outputCharInt;
        char outputChar;
        string line = string.Empty;
    
        while (-1 != (outputCharInt = streamReader.Read()))
        {
            outputChar = (char)outputCharInt;
            if (outputChar == '\n' || outputChar == '\r')
            {
                if (line != string.Empty)
                {
                    ProcessLine("Output: " + line);
                }
    
                line = string.Empty;
            }
            else
            {
                line += outputChar;
    
                if (line.Contains("login as:"))
                {
                    _processTest.StandardInput.Write("myusername");
                    _processTest.StandardInput.Write("\n");
                    _processTest.StandardInput.Flush();
                }
    
                if (line.Contains("'s password:"))
                {
                    _processTest.StandardInput.Write("mypassword");
                    _processTest.StandardInput.Write("\n");
                    _processTest.StandardInput.Flush();
                }
            }
        }
    }
    
    private static void ProcessLine(string line)
    {
        if (line != null)
        {
            WcfServerHelper.BroadcastRemoteCallback(x => x.PlinkTextOutput(line, DateTime.Now));
    
            if (line.Contains("If you do not trust this host, press Return to abandon the"))
            {
                _processTest.StandardInput.Write("y");
                _processTest.StandardInput.Write("\n");
                _processTest.StandardInput.Flush();
            }
    
            if (line.Contains("Access granted"))
            {
                if (!_processTest.HasExited)
                    _processTest.Kill();
    
                WcfServerHelper.BroadcastRemoteCallback(x => x.TestConnectionCallback(PlinkStatus.Success));
            }
            else if (line.Contains("Access denied") || line.Contains("Password authentication failed"))
            {
                if (!_processTest.HasExited)
                    _processTest.Kill();
    
                WcfServerHelper.BroadcastRemoteCallback(x => x.TestConnectionCallback(PlinkStatus.InvalidUserOrPass));
            }
            else if (line.Contains("Host does not exist"))
            {
                if (!_processTest.HasExited)
                    _processTest.Kill();
    
                WcfServerHelper.BroadcastRemoteCallback(x => x.TestConnectionCallback(PlinkStatus.InvalidHostname));
            }
            else if (line.Contains("Connection timed out"))
            {
                if (!_processTest.HasExited)
                    _processTest.Kill();
    
                WcfServerHelper.BroadcastRemoteCallback(x => x.TestConnectionCallback(PlinkStatus.TimedOut));
            }
        }
    
    }
