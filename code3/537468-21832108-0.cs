               if (client.Client.Poll(0, SelectMode.SelectRead))
               {
                  read = 0;
                  read = br.Read(buffer, 0, buffer.Length);
                  if (read > 0)
                  {
                     Console.Write(Encoding.ASCII.GetString(buffer, 0, read));
                  }
                  else
                     throw new Exception("Socket closed");
               }
