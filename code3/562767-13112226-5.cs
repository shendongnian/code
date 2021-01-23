    void callback(IAsyncResult ar)
    {
          try
          {
               Socket s = this.s.EndAccept(ar);
               if (SocketAccepted != null)
               {
                    SocketAccepted(s);
               }
               this.s.BeginAccept(callback, null);
          }
          catch (Exception ex)
          {
               if (!ex.Message.Contains("asyncResult")) //Proceed only if the exception does not contain asyncResult
               {
                    MessageBox.Show(ex.Message);
               }
          }
    }
