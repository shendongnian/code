    public class UnlimitedGenericArray<T>
    {
        public IList<T> List { get; set; }
        
        private IDictionary<Type,Func<object,T>> InserterFuncDict{get;set;}
        
        public UnlimitedGenericArray(IDictionary<Type,Func<object,T>> inserterDict)
        {
            this.List = new List<T>();
            this.InserterFuncDict = inserterDict;
        }
        
        public void AddItem(object item)
        {
            var itemType = item.GetType();
            if(itemType == typeof(T))
            {
                this.List.Add((T)item);
            }
            else if(this.InserterFuncDict.ContainsKey(itemType))
            {
                this.List.Add(this.InserterFuncDict[itemType](item));
            }
            else 
            {
                var msg = "I don't know how to convert the value: {0} of type {1} into type {2}!";
                var formatted = string.Format(msg,item,itemType,typeof(T));
                throw new NotSupportedException(formatted);
            }
        }
        
    }
