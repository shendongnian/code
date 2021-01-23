    byte[] EndOfMessage = System.Text.Encoding.ASCII.GetBytes("image_end");
    byte[] ReceivedBytes;
    
    while(!IsEndOfMessage(ReceivedBytes))
    {
    //continue reading from socket and adding to ReceivedBytes
    }
    
    ReceivedBytes = RemoveEndOfMessage(ReceivedBytes);
    PrintImage(ReceivedBytes);
