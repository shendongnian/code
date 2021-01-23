            public bool Predicate (string a, object obj)
            {
              // blah blah    
            }
        
            public void Test()
            {
                var obj = "Object";
                var items = new string[]{"a", "b", "c"};
                var result = items.Where(x => Predicate(x, obj)); // here I want to somehow supply obj to Predicate as the second argument
            }
