    class Collection
    {
        Dictionary<string, object> values = new Dictionary<string, object>();
        public object this[string index]
        {
            get
            {
                if(values.ContainsKey(index)
                {
                  return values[index];
                }
                return null;
            }
            set
            {
                if(!values.ContainsKey(index)
                {
                  values.Add(index, value);
                }
            }
        }
    } 
