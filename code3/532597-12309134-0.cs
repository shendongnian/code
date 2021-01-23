    public static IQueryable<Store> FindActiveByName()
    {
        var r = new ReadRepo<Store>(Local.Items.Uow.Context);
        Tuple<string, string> range = Tuple.Create("0", "9");
        return r.Find().Where(s => 
            range.Item1.CompareTo(s.Name.Substring(0, 1)) <= 0 &&
            s.Name.Substring(0, 1).CompareTo(range.Item2) <= 0);
    }
