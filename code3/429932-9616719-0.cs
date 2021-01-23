    class TimedDataItemComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is TimedDataItem && y is TimedDataItem)
                // let's assume TimeStamp is public
                return ((TimedDataItem)x).Timestamp.CompareTo(((TimedDataItem)y).Name);
            else
                return -1;
        }
    }
    TimedDataItem item1 = new .....
    // non generic
    SortedList sl = new SortedList(new TimedDataItemComparer());
    sl.Add(item1, item1);   // add key/value pair
    // generic, choose typ of key as you wish
    SortedList<TimedDataItem, TimedDataItem> sl = 
            new SortedList<TimedDataItem, TimedDataItem>(new TimedDataItemComparer());
    sl.Add(item1, item1);   // add type safe key/value pair
    // or make use of SortedSet<T>
    class TimedDataItemComparer : IComparer<TimedDataItem>
    {
      public int Compare(TimedDataItem x, TimedDataItem y)
      {
        return x.Timestamp.compareTo(y.Timestamp);
      }
    }
    SortedSet<TimedDataItemComparer> ss = new SortedSet<TimedDataItemComparer>();
    ss.add(item1);
    // afterwards access first or last item
