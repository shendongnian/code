    struct Data
    {
        double Percent;
        int Count;
    }
    ...
    List<Data> items = new List<Data> ();
    ... // fill your list with Data instances, initialized with values
    double total = 0; // running total
    int totalcount = 0; // total number of items
    for ( int i = 0; i < items.Count; i++ )
    {
        totalcount += items[i].Count;
        total += ( items[i].Count * items[i].Percent );
    }
    double result = total / totalcount;
