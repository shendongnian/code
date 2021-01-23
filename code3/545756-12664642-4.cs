    class TaskItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        internal void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private string title;
        public string Title 
        { 
           get { return title; } 
           set 
           { 
               if (title == value) return;
               title = value;
               NotifyPropertyChanged("Title");
           }
        }
        public TaskItem (string -title) 
        { title = _title; }  
        // does not fire setter title lower case 
        // but the UI will have this value as ctor fires before render 
        // so get will reference the assigned value of title 
    }
