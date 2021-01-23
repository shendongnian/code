    int messageRead = 0;
    while(messageRead < message.Length)
    { 
        int bytesRead = clientStream.Read(message, messageRead, message.Length - messageRead);
        messageRead += bytesRead;
        if(bytesRead==0)
            return;   // The socket was closed
    }
    // Here you have a full message
