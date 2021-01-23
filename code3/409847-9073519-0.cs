    class MySerialPort
    {
       static object synchLock = new object();
       public void DoSomething()
       {
          lock (synchLock)
          {
            // whatever
          }
       }
    }
