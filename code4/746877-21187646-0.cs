    private static void GetData()
    {
       dynamic dynamicList = FetchData();
       if (dynamicList is IEnumerable) //handles null as well
           FilterAndSortDataList(Enumerable.ToList(dynamicList));
       //throw; //better meaning here.
    }
