          var t = new Thread(new ThreadStart(() =>
          {
            while (true)
            {
              if (!Debugger.IsAttached)
              {
                //Check if the IsAttached Changed raise a custom event DebuggerDetached
              }
              else
              {
                //Check if the IsAttached Changed raise a custom event DebuggerAttached
              }
    
              Thread.Sleep(100);
            }
          }));
    
          t.Start();
