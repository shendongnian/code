    public ChildClass
    {
        private ParentClass parent;
    
        public ChildClass(ParentClass parent)
        {
            this.parent = parent;
        }
    
        public void LoadData(DateTable dt)
        {
           // do something
           parent.CurrentRow++; // or whatever.
           parent.UpdateProgressBar(); // Call the method
        }
    }
