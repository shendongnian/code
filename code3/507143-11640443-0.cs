    //This is your MAIN thread
    Thread t = new Thread(new ParameterizedThreadStart(t1));
    t.Start(new Class1());
    //...
    lock(c)
    {
      c.magic_is_done = true;
    }
    //...
    
    public static void t1(Class1 c)
    {
      //this is your SECOND thread
      bool stop = false;
      do
      {
        Console.Write(".");
        Thread.Sleep(1000);
    
        lock(c)
        {
          stop = c.magic_is_done;
        }
        while(!stop)
      }
    }
