     for (int j = 1; j <= 5; j++)
     {
         int jCopy = j;
         tasks1.Add(Task.Factory.StartNew(() =>
          {
              Console.WriteLine(jCopy);
          }, new CancellationToken(), TaskCreationOptions.LongRunning, TaskScheduler.Default)
         );
     }
