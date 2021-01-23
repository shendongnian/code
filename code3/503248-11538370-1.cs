    public class ListViewItemComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            YourType a = (YourType)((ListViewItem)x).Tag;
            YourType b = (YourType)((ListViewItem)y).Tag;
            // compare tags
            return a.CompareTo(b);
        }
    }
