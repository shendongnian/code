    private static void GetData()
    {
       dynamic dynamicList = new List<string> ();
       FilterAndSortDataList((List<string>)dynamicList);
    }
    
    private static void FilterAndSortDataList<T>(List<T> dataList)
    {
        ...
    }
