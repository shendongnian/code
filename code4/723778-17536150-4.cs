    public class MyDoubleStringDictionary<T> : IMyDoubleStringDictionaryBase<T>
    {
        private Dictionary<string,Dictionary<string,T>> _baseCollection;
        
        public T this[string index1, string index2]
        {
            get
            {
                if(_baseCollection.ContainsKey(index1))
                {
                    var nextDict = _baseCollection[index1];
                    if(nextDict.ContainsKey(index2))
                    {
                        return nextDict[index2];
                    }
                }
               
                return default(T);
            }
            set
            {
                Dictionary<string,T> nextDict;
                if(_baseCollection.Contains(index1))
                {
                    nextDict = _baseCollection[index1];
                }
                else
                {
                    nextDict = new Dictionary<string,T>();
                    _baseCollection.Add(index1,nextDict);
                }
                
                nextDict[index2] = value;
            }
        }
    }
