    public void ApplyRules()
    {
        var saveQueries = new List<Tuple<string, object[]>>();
        foreach(var item in list)
        {
            //Do something
            saveQueries.Add(SaveQuery(reasonId, ...));
        }
        using(var context = new SpecializedDBEntities())
        {
            foreach(var saveQuery in saveQueries)
            {
                testContext.Database.ExecuteSqlCommand(saveQuery.Item1, saveQuery.Item2);
            }
            ctx.SaveChanges();
        }
    }
    private Tuple<string, object[]> SaveQuery(int reasonId, ...)
    {
        const string query = 
             "INSERT INTO ORDER_IMPLEM_DTL_REASON " +
             "(ORDER_IMPLEM_REASON_ID, SALES_ORDER_IMPLEM_DTL_ID, REASON_ID, REASON_STAT_ID, SALES_ORDER_BRDCST_ID, CREA_BY, CREA_DT)" +
             " VALUES {0}, {0}, {1}, {2}, {3}, {4}, {5}";
        object[] values = new object[]{
            orderSpot.SALES_ORDER_IMPLEM_DTL_ID,
            reasonId,
            Common.Convert_Int64(orderSpot.CUESHT_STAT_ID),
            orderSpot.SALES_ORDER_DTL_BRDCST_ID, 
            userContext.User.USER_CD, 
            DateTime.Now.ToUniversalTime().ToString("yy-MM-dd hh:mm")
        };
        return new Tuple<string, object[]>(query, values);
    }
