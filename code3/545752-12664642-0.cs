    class TaskItem
    {
        private string title;
        public string Title 
        { 
           get { return title; } 
           set { title = value: }
        }
        public TaskItem (string Title) 
        { title = Title; }  // does not fire set title lower case
    }
