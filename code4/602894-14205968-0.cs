     Delegate[] delegates = myEvent.GetInvocationList();
     foreach (Delegate d in delegates)
     {
         try {
             d.DynamicInvoke(sender, args);
         } catch {
         }
     }
