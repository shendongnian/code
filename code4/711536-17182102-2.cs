    public ObservableCollection<Worker> Workers
    {
        get 
        { 
           var workerList = DataManager.Data.MasterWorkerList.Where(w => w.Known == true);
           return workerList.ToObservableCollection<Worker>();
        }
        set 
        { 
           DataManager.Data.MasterWorkerList = value;
        }
    }
