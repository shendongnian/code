    static int workerCount = 11; // one more for the main BW
    static int completedWorkerCount = 0;
    
    static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Console.WriteLine("All");
        updateAllWorkersProgress()
    }
    static void inBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
         Console.WriteLine(e.Result as String);
         updateAllWorkersProgress();
    }
    static void updateAllWorkersProgress()
    {
         if (++completedWorkerCount == workerCount)
         {
               Console.WriteLine("Everything completed");
         }
    }
