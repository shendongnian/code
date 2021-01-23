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
        public TaskItem (string Title) 
        { title = Title; }  // does not fire set title lower case
    }
