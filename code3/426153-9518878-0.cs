       public class SortByDateTime: IComparer  {
          // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
          int IComparer.Compare( Object x, Object y )  {
              // Compare objects according to the date
              }
          }
       ...
       // Sort the arraylist using the custom comparer
       IComparer myComparer = new SortByDateTime();
       ArrayList<MyClass> mList = new ArrayList<MyClass>();
       mList.Sort(myComparer);
     
