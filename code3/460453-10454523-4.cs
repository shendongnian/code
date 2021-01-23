    public System.Collections.IEnumerable GetItems()
    {
        for (ListViewItem in ListView)
        {
            //Get string from ListViewItem and specify a filtering condition
            string str = //Get string from ListViewItem
            //Filter condition . e.g. if(str = x)
            yield return str;
        }
    }
