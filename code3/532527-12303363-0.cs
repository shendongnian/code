    public abstract class Parent
    {
        public void ToDo()
        {
            Pre();
    
            DetailStep();
    
            Post();
        }
    
        protected abstract void DetailStep();
    }
