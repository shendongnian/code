    public static class MyListExtensions
    {
      public static IEnumerable<MyListItemType> ToIEnumerable(this MyList list)
      {
        return new Wrapper(list)
      }
      private class Wrapper : IEnumerable<MyListItemType>
      {
        readonly MyList list;
        public Wrapper(MyList list)
        {
          this.list = list;
        }
        public IEnumerator<MyListItemType> GetEnumerator() 
        { 
          for (int i = 0; i < list.GetCount(); ++i )
          { 
            yield return list.At(i); 
          } 
        } 
      } 
    }
