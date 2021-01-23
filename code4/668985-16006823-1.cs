    public class DateComparer: IComparer  {
    int IComparer.Compare( Object x, Object y )  {
        String a = (x as ListItem).Text;
        String b = (y as ListItem).Text;
        DateTime aDate = DateTime.Parse(a.split(null)[0]);
        DateTime bDate = DateTime.Parse(b.split(null)[0]);
        return DateTime.Compare(aDate, bDate);        
      }
    }
