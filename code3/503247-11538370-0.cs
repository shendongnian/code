    public class ListViewItemComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((YourType)(ListViewItem)x).Tag).CompareTo(((ListViewItem)y).Tag);
        }
    }
