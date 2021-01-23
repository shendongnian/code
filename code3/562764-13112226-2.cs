    void client_Received(Client sender, byte[] data)
    {
         if (Encoding.Default.GetString(data) != "") //Proceed only if data is not blank
         {
              Invoke((MethodInvoker)delegate
              {
                   consoleWrite(DateTime.Now + "-" + sender.EndPoint + " :\n" + Encoding.Default.GetString(data) + "\n\n", Color.White); ;
                });
              }
         }
    }
