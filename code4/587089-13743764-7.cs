    public ChildClass
    {
        private IParentClass parent;
    
        public ChildClass(IParentClass parent)
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
