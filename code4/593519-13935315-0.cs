    public class BaseModel
    {
        protected string TableName { get; set; }
    
        public BaseModel()
        {         
        }
    
        public abstract void Save();
    }
