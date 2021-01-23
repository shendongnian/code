    SerialPort sp;
    public byte[] SendCommand(byte[] command)
      {
          //System.Threading.Thread.Sleep(100);
          lock (sp)
          {
              Console.Out.WriteLine("ENTER");
              try
              {
                  string base64 = Convert.ToBase64String(command);
                  string request = String.Format("{0}{1}\r", target_UID, base64);
                  Console.Out.Write("Sending request... {0}", request);
                  sp.Write(request);
                  string response;
                  do
                  {
                      response = sp.ReadLine();
                  } while (response.Contains("QQ=="));
                  Console.Out.Write("Response is: {0}", response);
                  return Convert.FromBase64String(response.Substring(target_UID.Length));
              }
              catch (Exception e)
              {
                  Console.WriteLine("ERROR!");
                  throw e;
              }
              finally
              {
                  Console.Out.WriteLine("EXIT");
              }
          }
      }
