             // Open queue
         MQQueue q = MQQueueManager.AccessQueue( ...);
         using (CommittableTransaction transScope = new CommittableTransaction())
         {
               CommittableTransaction.Current = transScope;
               try
               {
                   MQMessage mqMsg = new MQMessage();
                   
                   // Add message contents
                   mqMsg.Write(<data>);
                   q.Put(mqMsg);
                   
                   transScope.Commit();
               }
               catch (Exception ex)
               {
                    transScope.Rollback();
                    Console.Write(ex);
                }
               CommittableTransaction.Current = null;
             }
