    do 
    {
               
      bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                
      page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            
    } while (bytes > 0);
