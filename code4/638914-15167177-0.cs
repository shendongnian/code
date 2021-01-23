ListView.Items.SortDescriptions.Add(new SortDescription("MyPropertyToSortOn", ListSortDirection.Descending))
    public class MyPropertyClass: IComparable{
      public int CompareTo(object obj) {
        //custom comparison implemented here, returns -1,0 or 1
      }
    }
...
    public class MyDataClass{
       public MyPropertyClass MyPropertyToSortOn {get;set;}
    }
