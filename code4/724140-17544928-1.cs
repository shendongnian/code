    ClassA
    {
      ManualResetEvent mre = new ManualResetEvent(false);
      Timer tmr = new Timer(1000);
      void Start()
         {
           tmr.start();
         }
    
      void tmr_Elapsed(object sender, ElapsedEventArgs e)
            {
    
                x++;
                if (x > 50)
                {
                    //Do Something
    
                    tmr.Stop(); // Or Change Value of a Property! anything that shows it
                                //meets the condition.
                    mre.Set();
                }
            }
    
      public void Wait()
      { 
         mre.WaitOne();
      }
    }
    
    
    Class WorkflowController
    {
       list<ClassA> allA=new list<ClassA>(){new A1,new A2, new A3}
       void Start()
       {
         foreach(item in allA)
         {
            item.start();
            item.Wait();
         } 
       }
    }
