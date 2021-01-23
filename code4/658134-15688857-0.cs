    public class MyDic : IDictionary<object, object>
    {
        private Dictionary<object, object> privateDic= new Dictionary<object,object>();
    
    
        public void Add(object key, object value)
        {
            if (value.GetType() == typeof(string))
                throw new ArgumentException();
            privateDic.Add(key, value);
        }
        //Rest of the interface follows
    }
