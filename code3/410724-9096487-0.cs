    public class Registry 
    {     
        protected readonly Dictionary<int, string> _items = new Dictionary<int, string>();    
        protected readonly object _lock = new object();       
        public void Register(int id, string val)     
        {     
            // Also lock when the dictionary is updated
            lock(_lock)
            {    
                _items.Add(id, val);     
            }
        }          
        public IEnumerable<int> Ids     
        {
            get      
            {
                lock (_lock)             
                {                 
                    return _items.Keys;             
                }         
            }     
        } 
    } 
