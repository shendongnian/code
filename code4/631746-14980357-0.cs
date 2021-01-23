    public class MyObject
    {
        public string Fruits{get;set;}
        
        public IList<string> FruitList 
        {
            get
            {
                var list = new ObservableCollection<string>(Fruits.Split(','));
                list.CollectionChanged += (s,ea) => {
                   var items = (IList<string>)s;
                   Fruits = String.Join(",",items);
                };
                return list;
            }
        }
    }
