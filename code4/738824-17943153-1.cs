    public class DateComparer : IComparer {
      public int Compare(DateTime x, DateTime y) {
        if(x.Date > y.Date)
             return 1;
        if(x.Date < y.Date)
             return -1;
        else
             return 0;
      }
    }
    list.Sort(new DateComparer());
