    class ModelProvider<T>  // (optionally) where T: baseClassOfUserAndProject
    {
        private T model;
  
        public void SetModel(T model) 
        {
            this.model = model;
        }
        public T GetModel() 
        {
            return this.model;
        }
    }
