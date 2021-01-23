     public string Task
     {
         get { return _task; }
         set
         {
             if(_task != value)
             {
                _task= value;
                NotifyPropertyChanged("Task");
             }
         }
     }
