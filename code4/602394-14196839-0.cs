    private List<TNews> GetPagedNews(int pagenum, int pagesize,
        AdvSearcherArgs advcArgs, string keyword)
    {
        var dataSrc = _dbRawDataContext.TNews.Where(x => x.Id>0);
        if (!string.IsNullOrWhiteSpace(advcArgs.PMAC))
        {
            dataSrc = dataSrc.Where(m => m.Pmac == advcArgs.PMAC);
        }
        if (!string.IsNullOrWhiteSpace(advcArgs.BegineDate))
        {
            var begin = Convertion.ToDate(advcArgs.BegineDate);
            var end = Convertion.ToDate(advcArgs.EndDate);
            dataSrc = dataSrc.Where(m => m.PmacDT >=begin && m.PmacDT<end);
        }
        dataSrc = dataSrc.OrderByDescending(n => n.PmacDT).Skip(pagenum * pagesize).
          Take(pagesize);
        var myList = dataSrc.ToList(); //execute the query to an in-memory list
        var cnt = myList.Count(); //get the count from the already exeuted query
        SetPagerValues(pagenum, pagesize, cnt);
        return myList; //return the list
    }
