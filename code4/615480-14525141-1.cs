    using(var context = new DataContext(connectionString))
    {
        var allXNotDeleted =
            from w in context.GetTable<CoolTable>()
            where x.IsDeleted != false;
        var allXWithCompleteStatus = (
            from notDeleted in allXNotDeleted
            join s in context.GetTable<XStatuses>()on notDeleted.StatusID equals s.StatusID
            where s.StatusID == 1
            select notDeleted)
            .Tolist();
        return allXwithCompleteStatus;
    }
