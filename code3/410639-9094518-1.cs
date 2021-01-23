       class SomeCollection<T> where T : IComparable<T>
       {
          private List<T> items; 
    
          private void Sort()
          {
             //
             T item1;
             T item2;
             if(item1.CompareTo(item2) < 0)
             {
                //bla bla
             }
          }
       }
