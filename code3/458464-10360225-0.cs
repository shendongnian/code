    public static void Print<T>(IEnumerable<T> items)
    {
        Debug.WriteLine(string.Join("\r\n", items.Select((index, item) =>
                            string.Format("{0}: {1}", index, item))));
    }
