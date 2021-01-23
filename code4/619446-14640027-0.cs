    Dictionary<string, List<DateTime>> SearchDate = 
        new Dictionary<string, List<DateTime>>();
    ...
    public void AddItem(string key, DateTime dateItem)
    {
        var listForKey = SearchDate[key];
        if(listForKey == null)
        {
            listForKey = new List<DateTime>();
        }
        listForKey.Add(dateItem);
    }
