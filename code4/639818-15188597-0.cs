     //item class
     public class Item<T>
        {
          T Value {get;set;}
        }
        
        //usage example
        private List<String> items = new List<string>();
        
        public void AddItem( Item<string> item)
        {
            items.Add(item);
        }
        
        public void SetItem(Item<T> item,string value)
        {
          item.Value=value;
        }
