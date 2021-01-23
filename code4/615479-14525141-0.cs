    using(var x = new fooDataContext())
    using(var y = new barDataContext())
    {
        var allXNotDeleted =
            from w in x.CoolTable
            where x.IsDeleted != false;
        var allXWithCompleteStatus = (
            from notDeleted in allXNotDeleted
            join s in y.XStatuses on notDeleted.StatusID equals s.StatusID
            where s.StatusID == 1
            select notDeleted)
            .Tolist();
        return allXwithCompleteStatus;
    }
