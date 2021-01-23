    public void ThreadStartClient(object obj)
            {
                // Ensure that we only start the client after the server has created the pipe
                ManualResetEvent SyncClientServer = (ManualResetEvent)obj;
    
                using (NamedPipeClientStream pipeStream = new NamedPipeClientStream(".", "MyPipe", PipeDirection.InOut))
                {
    
                    // The connect function will indefinately wait for the pipe to become available
                    // If that is not acceptable specify a maximum waiting time (in ms)
                    pipeStream.Connect();
    
                    if (!pipeStream.IsConnected)    //It thinks it's connected but can't read anything ....
                    {
                        MessageBox.Show("Failed to connect ....");
                        return;
                    }
    
                    //Read server reply
                    StreamReader sr = new StreamReader(pipeStream);
    
                    char[] c = new char[200];
    
                    while (sr.Peek() >= 0)
                    {
                        sr.Read(c, 0, c.Length);
                    }
    
                    string s = new string(c);
                    MessageBox.Show(s);
                }
            }
