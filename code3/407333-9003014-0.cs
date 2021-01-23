       class ItemFactory<T> where T : new()
       {
          public T GetNewItem()
          {
             return new T();
          }
       }
    
       class Foo : ItemFactory<Bar>
       {
    
       }
    
       class Bar
       {
          public Bar(int a)
          {
    
          }
       }
