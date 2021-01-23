    public class MyObject
    {
        private string fruits;
        private ObservableCollection<string> fruitList;
        public string Fruits
        {
            get{ return this.fruits; }
            set
            {
                this.fruits = value;
                this.fruitList = CreateFruitList();
            }
        }
        
        private ObservableCollection<string> CreateFruitList()
        {
            var list = new ObservableCollection<string>(this.fruits.Split(','));
            list.CollectionChanged += (s,ea) => {
               var items = (IList<string>)s;
               this.fruits = String.Join(",",items);
            };
            return list;
        }
            
        
        public IList<string> FruitList 
        {
            get
            {
                
                return fruitList;
            }
        }
    }
