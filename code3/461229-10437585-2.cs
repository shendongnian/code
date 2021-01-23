    public class FileWorkerService
    {
       private BackgroundWorker _worker;
       public FileWorkerService()
        {
           _worker = new BackgroundWorker();
        }
    
       public void ReadFileAndProcessIt()
        {
          if (!_worker.IsBusy)
            {
              _worker.RunWorkerAsync();
            }
        } 
     }
