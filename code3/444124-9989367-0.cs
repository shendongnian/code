    public class MyListSorter : IComparer<MyObject>
    {
      public int Compare(MyObject obj1, MyObject obj2)
      {
        if ( !Char.IsNumber(obj1) && Char.IsNumber(obj2) )
        {
           return 0;
        }
        else if ( Char.IsNumber(obj1) && !Char.IsNumber(obj2) )
        {
          return 1;
        }
        else
        {
          return obj2.CompareTo(obj1);
        }
      }
    }
