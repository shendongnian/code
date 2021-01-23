    public class Pool
    {
        private ConcurrentDictionary<string, object> m_data = new ConcurrentDictionary<string, object>();
    
        public T Take<T>(string key)
        {
            //fetch data from the dictionary and convert it to the type you want
        }
    
        //other methods like Insert...
    }
