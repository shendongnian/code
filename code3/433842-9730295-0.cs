    class Task : INotifyPropertyChanged
    {
        public string name;
        public string desc;
        public int pr;
    
        public string TaskName
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("TaskName"); 
            }
        }
    
        public string Description
        {
            get { return desc; }
            set 
            { 
                desc = value; 
                OnPropertyChanged("Description"); 
            }
        }
    
        public int Priority
        {
            get { return pr; }
            set 
            {
                pr = value;
                OnPropertyChanged("Priority"); 
            }
        }
    
        public Task(string name, string description, int pr)
        {
            this.TaskName = name;
            this.Description = description;
            this.Priority = pr;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
            
        public void OnPropertyChanged(string pName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(pName));
            }
        }
    }
