     switch (args[x])
     {
     #region --test-net
         case "--test-net":
              Task isAlive = Task.Factory.StartNew(() =>
              {
                  bool alive = tlib.CheckForInternetConnection();
                  if (!alive)
                  {
                      while (!alive)
                      {
                          Console.WriteLine("No connectivity found.");
                          System.Threading.Thread.Sleep(9000);
                          alive = tlib.CheckForInternetConnection();
                      }
                  }
                  else
                  {
                       //TODO: Add alive code here 
                  }
              });
              isAlive.Wait();
              break;
              #endregion
    }
