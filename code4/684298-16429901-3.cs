    var results =
        (from d in mContext.Docs
         orderby d.Title ascending
         join b in mContext.Base on d.DocId equals b.DocId
         join h in mContext.ViewDocItems on b.BaseId equals h.BaseId
         where h.ItemId == mGuid
         select new
         {
             Id = d.DocId, 
             Title = d.Title, 
             ClassId = d.ClassId,
             BaseHis =
                 from b in d.Base
                 orderby b.LineNumber
                 select new BaseHistory
                 {
                     BaseId = d.BaseId,
                     Name = d.Title,
                     BaseFinal = d.Final.Value,
                     LineNumber = d.LineNumber.Value
                 }
        });
    foreach(var r in results)
    {
        var hist = new DocHistory() 
        {
            Id = r.Id,
            Title = r.Title,
            ClassId = d.ClassId;
        };
        foreach(var h in r.BaseHis)
        {
            hist.BaseHis.Add(h);
        }
        mHistory.Add(r); 
    }
