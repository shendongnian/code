    class NotificationWrapper<TSource, TResult>
    {
       private readonly TSource originalSource;
    
       private Queue<TResult> resultsGenerated = new Queue<TResult>()
    
       private int workerCount = 0;
    
       public NotificationWrapper<TSource, TResult>( TSource originalSource, int workerCount )
       {
           this.originalSource = originalSource;
           this.workerCount = workerCount;
       }
    
       public void NotifyActionDone()
       {
           lock( this )
           {
              --workerCount;
              if ( 0 == workerCount )
              {
                 //do my sending
                 send( originalSource, resultsGenerated );
              }
           }
       }
    
        public void NotifyActionDone( TResult result )
        {
            lock ( this )
            {
                resultsGenerated.push( result );
                NotifyActionDone();
            }
        }
    }
