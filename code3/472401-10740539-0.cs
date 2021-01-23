        public void ThreadStartClient(object obj)
        {
                // Ensure that we only start the client after the server has created the pipe
                ManualResetEvent SyncClientServer = (ManualResetEvent)obj;
                // Only continue after the server was created -- otherwise we just fail badly
                // SyncClientServer.WaitOne();
                using (NamedPipeClientStream pipeStream = new NamedPipeClientStream(".", "SAPipe"))
                {
                    // The connect function will indefinately wait for the pipe to become available
                    // If that is not acceptable specify a maximum waiting time (in ms)
                    pipeStream.Connect();
                    //Write from client to server
                    StreamWriter sw = new StreamWriter(pipeStream))
                    sw.WriteLine("What's your status?");
                    //Read server reply
                    StreamReader sr = new StreamReader(pipeStream)
                    string temp = "";
                    temp = sr.ReadLine();   //Pipe is already closed here ... why?
                    MessageBox.Show(temp);
                }
        }
