    var sorted = uiItems.OrderBy(x => x.Contact, new YourComparer ());
   
    public class YourComparer : IComparer<Contact>
    {
        public int Compare(Contact? x, Contact? y)
        {
            if (x == y)
                return 0;
            if (x == null)
                return 1;
            if (y == null)
                return -1;
            if (x.Presence == null)
                return 1;
            if (y.Presence == null)
                return -1;
            return return x.Presence < y.Presence ? -1 : 1;
        }
    }
