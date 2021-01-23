c#
public static class ObservableCollectionExtensions
{
    public static int FindIndex<T>(this ObservableCollection<T> ts, Predicate<T> match)
    {
        return ts.FindIndex(0, ts.Count, match);
    }
    public static int FindIndex<T>(this ObservableCollection<T> ts, int startIndex, Predicate<T> match)
    {
        return ts.FindIndex(startIndex, ts.Count, match);
    }
    public static int FindIndex<T>(this ObservableCollection<T> ts, int startIndex, int count, Predicate<T> match)
    {
        if (startIndex < 0) startIndex = 0;
        if (count > ts.Count) count = ts.Count;
        for (int i = startIndex; i < count; i++)
        {
            if (match(ts[i])) return i;
        }
        return -1;
    }
}
Usage:
int index = PLUList.FindIndex(x => x.ID == 13);
if (index > -1)
{
    // Do something here...
}
else
{
    // Do something else here...
}
