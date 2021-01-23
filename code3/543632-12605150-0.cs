    static int workerCount = 10;
    static int completedWorkerCount = 0;
    
    static void inBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
         Console.WriteLine(e.Result as String);
         if (++completedWorkerCount == workerCount)
         {
               Console.WriteLine("Everything completed");
         }
    
    }
