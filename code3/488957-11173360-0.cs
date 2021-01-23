    tasks[taskCount] = Task.Factory.StartNew(() =>
         {
            var result = EvaluateRules(temp);
            
            var toBeDisposed = result;
            lock(Leader) // should be locking on a private object
            {
               if (result.Value > Leader[0].Value)
               {
                 toBeDisposed = Leader[0];
                 Leader[0] = result;
               }
            }
        
            toBeDisposed.Dispose();       
        
         });
