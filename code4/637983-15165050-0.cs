    if (dataToSend.IsEmpty)
    {
         //Declare that we are no longer the consumer.
         Interlocked.Decrement(ref RunningWrites);
    
         //Double check the queue to prevent race condition A
         if (Queue.IsEmpty)
             return;
         else
         {   //Race condition A occurred. There is data again.
             
             //Let's try to become a consumer.
             if (Interlocked.CompareExchange(ref RunningWrites, 1, 0) == 0)
                   continue;
    
             //Another thread has nominated itself as the consumer. Our job is done.
             return;
         }                                    
    }
                                
    break;
