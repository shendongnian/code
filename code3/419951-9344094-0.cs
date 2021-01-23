    public class GeneralWrapper<T> where T : class, new()
    {
        public GeneralWrapper()
        {
           Datas = new T();
        }
    
        public T Datas { get; set; }
    }
