    public IEnumerable<Tuple<T1, T2, T3>> GetFiles()
    {
        using (TestEntities context = new TestEntities())
        {
            var query = from pf in context.T1
                        join pfExt in context.T2 on pf.Id equals pfExt.ProcessedFilesID
                        join st in context.T3 on pfExt.WFStatusID equals st.WFStatusID
                        select new { pf, pfExt, st };
            return query.AsEnumerable()
                        .Select(x => Tuple.Create(x.pf, x.pfExt, x.st));
        }           
    }
