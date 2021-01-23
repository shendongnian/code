    public class Matrix<T>
    {
      public T[][] UnderlyingCollection {get;set;} //should probably be readonly and set in the constructor
    
      public T DefaultValue {get;set;}
    
      public T this[int i, int j]
      {
        get
        {
          if(UnderlyingCollection.Length > i && UnderlyingCollection[i].Length > j)
            return UnderlyingCollection[i][j];
          else
            return DefaultValue;
        }
        set
        { /*TODO implement*/ }
        
      }
    }
