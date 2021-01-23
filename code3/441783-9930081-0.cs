     public class CustomListWrapper< T, F>
        {
            private readonly List<object> internalList;
            public CustomListWrapper()
            {
                this.internalList = new List<object>();
            }
          
            public void Add(object item)
            {
                if(!(item is T || item is F))
                    throw new Exception();
    
                this.Add(item);
            }
          
        }
