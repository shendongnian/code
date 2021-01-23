    Task controllerTask = Task.Factory.StartNew(() =>
    {
     while(true)
     {
         if (cancellationToken.IsCancellationRequested) break;
         var sleepTime = 10;
         if (interval < sleepTime)
             interval = sleepTime;
         var iteration = (interval / sleepTime);
         if ((interval % sleepTime) > 0)
             iteration++;
         bool cancel = false;
         for (int i = 0; i < iteration; i++)
         {
             Thread.Sleep(sleepTime * 1000);
             if (cancellationToken.IsCancellationRequested) { cancel = true; break; };
         }
         if (cancel) break;
    
         //SOME WORK HERE
     }
    }
