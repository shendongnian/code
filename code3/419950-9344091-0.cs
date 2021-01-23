    public class GeneralWrapper<T> where T: new()
    {
        public GeneralWrapper()
        {
           Datas = new T();
        }
    
        public T Datas { get; set; }
    }
