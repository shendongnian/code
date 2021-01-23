        byte[] buffer = new byte[4155];
        int bytesRead = 0;
        using (var input = client.GetStream())
        {
          while (true)
                        {
                            bytesRead = input.Read(buffer, 0, buffer.Length);
                            totalBytes += bytesRead;
                            if (bytesRead > 0)
                                // keep processing ur data here, add it to another buffer maybe
                            else
                                break; // come out of while loop if there is no data
                        }
             
        }
      }
