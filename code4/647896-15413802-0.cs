    public List<InspectorSearchResult> Search(string keywords, int? areaId)
    {
        var qry = this.GetAllInspectors();
        if (!String.IsNullOrEmpty(keywords))
            qry = qry.Search(keywords);
        if (areaId.HasValue)
            qry = qry.ByAreaId(areaId.Value);
        var search = from i in qry
            from a in i.Areas
            orderby a.AreaName
            select new InspectorSearchResult
            {
                Area = a
            };
        foreach(var x in search)
        {
            x.Inspectors = (
                from ins in a.Inspectors
                orderby ins.LastName, ins.FirstName
                select ins)
                .ToList();
        }
        return search.ToList();
    }
