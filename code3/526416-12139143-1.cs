      class TheClass
     {
        static SemaphoreSlim _sem = new SemaphoreSlim (3);
 
        static void Main()   
        {     
           for (int i = 1; i <= 5; i++) 
           new Thread (Enter).Start (i);   
        } 
        static void Enter (object name)   
        {     
          Console.WriteLine (name + " wants to enter");    
          _sem.Wait();     
          Console.WriteLine (name + " has entered!");               
          Thread.Sleep (1000 * (int) name );              
          Console.WriteLine (name + " is leaving");       
          _sem.Release();   } 
         }
     }
