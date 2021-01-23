       public class MyClass : IEnumerable 
        {
            private List<string> items = new List<string>();
    
            public MyClass()
            {
                items.Add("first");
                items.Add("second");
            }
    
    
            public IEnumerator GetEnumerator()
            {
                return items.GetEnumerator();
            }
        }
