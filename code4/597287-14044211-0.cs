    public class UltraModel
    {
        // I recommend using an interface rather than a base class
        // to avoid potentially confusing types
        public IBaseModel Models { get; set; }
    
        public T getModelByType<T>()
        {
            return (T)Models.Where(x => x is T).FirstOrDefault();
        }
    }
