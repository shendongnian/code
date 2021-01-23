    static void Main()
    {
        ArrayList _arListDAte = new ArrayList();
        CustomListItem listItem = new CustomListItem();
        bool condition = true;
        DateTime date = new DateTime(2013, 04, 15);
        if(condition)
        {
           listItem.Text = date + " - Allowed";
           listItem.Date = date;
        }
        else
        {
           listItem.Text = date + " - Allowed";
           listItem.Date = date;
        }
        _arListDAte.Add(listItem);
        listItem = new CustomListItem();
        date = new DateTime(2013, 04, 13);
        if (condition)
        {
           listItem.Text = date + " - Allowed";
           listItem.Date = date;
        }
        else
        {
           listItem.Text = date + " - Allowed";
           listItem.Date = date;
        }
        _arListDAte.Add(listItem);
        listItem = new CustomListItem();
        date = new DateTime(2013, 04, 18);
        if (condition)
        {
           listItem.Text = date + " - Allowed";
           listItem.Date = date;
        }
        else
        {
           listItem.Text = date + " - Allowed";
           listItem.Date = date;
        }
        _arListDAte.Add(listItem);
        _arListDAte.Sort();
     }
     public class CustomListItem : IComparable
     {
         public string Text { get; set; }
         public string Value { get; set; }
         public DateTime Date { get; set; }
         //Sort Ascending Order
         public int CompareTo(object obj)
         {
             CustomListItem customListItem = obj as CustomListItem;
             if (customListItem != null)
                 return this.Date.CompareTo(customListItem.Date);
             return 0;
         }
         // Uncomment for descending sort
         //public int CompareTo(object obj)
         //{
         //    CustomListItem customListItem = obj as CustomListItem;
         //    if (customListItem != null)
         //        return customListItem.Date.CompareTo(this.Date);
         //    return 0;
         //}
     }
