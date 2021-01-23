    public Thread SocketStream(Socket s, StreamWriter logfile)
    {
        byte[] msg = null;
        int bytesSent = 0;
        
        msg = BitConverter.GetBytes(position.X);
        // Encode the data string into a byte array.
        bytesSent = s.Send(msg);
        
        Thread t = new Thread(()=>
        {
            int bytesExpected = 1024; // somehow specify the number of bytes expected
            int totalBytesRec = 0; // adds up all the bytes received
            int bytesRec = -1; // zero means that you're done receiving
            
            while(bytesRec != 0 && totalBytesRec <  bytesExpected )
            {
                // Receive the response from the remote device.
                bytesRec = s.Receive(incBuffer);
                totalBytesRec += bytesRec;
            }
        });
        t.IsBackground = true;
        t.Start();
        return t;
    }
