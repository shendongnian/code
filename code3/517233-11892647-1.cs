     private string _taskNumber;
     public string TaskNumber
     {
         get { return _taskNumber; }
         set
         {
             if(_taskNumber!= value)
             {
                _taskNumber= value;
                OnPropertyChanged("TaskNumber");
             }
         }
     }
