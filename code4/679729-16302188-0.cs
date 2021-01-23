    Task.Factory.StartNew(() =>
    {
        var server = new NamedPipeServerStream("MyPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
    
        StreamReader reader = new StreamReader(server);    
        Boolean connectedOrWaiting = false;
    
        while (true)
        {
    
            if (!connectedOrWaiting)
            {
                server.BeginWaitForConnection((a) => { server.EndWaitForConnection(a); }, null);    
                connectedOrWaiting = true;
            }
    
            if (server.IsConnected)
            {
                var line = reader.ReadLine();
    
                if (line != null)
                     System.Windows.Forms.MessageBox.Show("Data: : " + line);
    
                server.Disconnect();    
                connectedOrWaiting = false;
            }                    
        }
    });
