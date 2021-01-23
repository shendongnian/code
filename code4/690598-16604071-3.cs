    IEnumerable<IList<doc>> SplitDocumentList(IEnumerable<doc> allDocuments, int maxMB)
    {
        var lists = new List<IList<doc>>();
        var list = new List<doc>();
        foreach (doc document in allDocuments)
        {
            int totalMB = list.Sum(d => d.sizemb) + document.sizemb;
            if (totalMB > maxMB)
            {
                lists.Add(list);
                list = new List<doc>();
            }
            list.Add(document);
        }
        if (list.Count > 0)
            lists.Add(list);
        return lists;
    }
