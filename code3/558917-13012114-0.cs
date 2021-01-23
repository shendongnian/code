    void Main()
    {
       var pooling = new JustPooling();
    
       pooling.RunThread();
    
       Thread.Sleep(500);
    
       while (pooling.Operating)
       {
          Console.Write (" " + pooling.CurrentIndex);
          Thread.Sleep(500);
       }
    
       Console.Write(" Done");
       /* 1 1 2 2 2 3 3 3 4 4 4 5 5 5 Done */
    
    
    }
    
    // Define other methods and classes here
    
    public class JustPooling
    {
       public bool Operating { get; set; }
       public int CurrentIndex { get; set; }
    
       public void RunThread()
       {
           ThreadPool.QueueUserWorkItem(delegate
            {
                Operating = true;
                for ( int index = 0; index < 5; ++index )
                {
                    ++CurrentIndex;
                    Thread.Sleep( 1500 );
                }
                Operating = false;
            });
       }
    
    }
