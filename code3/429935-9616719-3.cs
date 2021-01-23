    ArrayList al = new ArrayList();
    al.Add(first);
    al.Add(second);
    al.Add(third);
    al.Add(fourth);
    al.Add(fifth);
    al.Add(seventh);
    al.Add(seventh);
    int index2 = al.BinarySearch(third, new TimedDataItemComparer2());
    // al[index2] does not make sense
    // as there is no guarantee, that al[index2-1] is the element
    // with previous DateTime ...
    class TimedDataItemComparer2 : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is TimedDataItem && y is TimedDataItem)
                return ((TimedDataItem)x).Timestamp.
                           CompareTo(((TimedDataItem)y).Timestamp);
            else
                return -1;
        }
    }
