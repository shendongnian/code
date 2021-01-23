    void ReceiveData(Socket s)
    {
        int bytesExpected = 1024; // somehow specify the number of bytes expected
        int totalBytesRec = 0; // adds up all the bytes received
        int bytesRec = -1; // zero means that you're done receiving
    
        while(bytesRec != 0 && totalBytesRec <  bytesExpected )
        {
            // Receive the response from the remote device.
            bytesRec = s.Receive(incBuffer);
            totalBytesRec += bytesRec;
            if(needToReply)
            {
                // Send another message
                SendData(s);
            }
        }
    }
