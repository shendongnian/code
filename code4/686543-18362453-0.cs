      [System.Diagnostics.DebuggerHidden] // ignore the annoying breaks when get exceptions here.
      internal static bool Ping<T>(T svr)
      {
         // Check type T for a defined Ping function
         if (svr == null) return false;
         System.Reflection.MethodInfo PingFunc = typeof(T).GetMethod("Ping");
         if (PingFunc == null) return false;
         // Create a new thread to call ping, and create a timeout of 5 secons
         TimeSpan timeout = TimeSpan.FromSeconds(5);
         Exception pingexception = null;
         System.Threading.Thread ping = new System.Threading.Thread(
            delegate()
            {
               try
               {
                  // just call the ping function
                  // use svr.Ping() in most cases
                  // PingFunc.Invoke is used in my case because I use
                  // reflection to determine if the Ping function is
                  // defined in type T
                  PingFunc.Invoke(svr, null);
               }
               catch (Exception ex)
               {
                  pingexception = ex;
               }
            }
         );
         ping.Start(); // start the ping thread.
         if (ping.Join(timeout)) // wait for thread to return for the time specified by timeout
         {
            // if the ping thread returned and no exception was thrown, we know the connection is available
            if (pingexception == null)
               return true;
         }
         // if the ping thread times out... return false
         return false;
      }
