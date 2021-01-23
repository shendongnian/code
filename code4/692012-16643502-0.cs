     byte[] data = new byte[1025];
     int length = 0;
     using (var stream =  request.GetBufferlessInputSream())
     {
         while (length < validData.Length)
         {
             int bytesRead = stream.Read(data, length, data.Length - length);
             if (bytesRead == 0)
             {
                 break;
             }
             length += bytesRead;
         }
     }
     if (length > 1024)
     {
         // Client sent more than 1024 bytes of data!
     }
     // Otherwise, use the first "length" bytes of data
