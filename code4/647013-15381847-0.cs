    SortedList<string, Page> pageList = new SortedList<string, Page>();
    for (int i = 0; i < 3; i++)
    {
        pageList.Add(string.Format("Page{0}", i), new Page());
    }
