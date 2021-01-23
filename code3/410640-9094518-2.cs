       class SortableGenericType<T> : IComparable, IComparable<SortableGenericType<T>> 
       {
          private string stringName;
          public T name { get; set; }
    
          public int CompareTo(SortableGenericType<T> ourObject)
          {
             //I forgot to add this statement:
             if(ourObject == null) 
                 return -1; 
             return stringName.CompareTo(ourObject.stringName);
          }
    
          public int CompareTo(object obj)
          {
             if (obj.GetType() != GetType())
                return -1;
             return CompareTo(obj as SortableGenericType<T>);
          }
       }
