    public static IQueryable<Store> FindActiveByName()
    {
        var r = new ReadRepo<Store>(Local.Items.Uow.Context);
    
        Tuple<char, char> range = Tuple.Create('0', '9');
    
        var letters = Enumerable
                         .Range(range.Item1, (int)range.Item2 - (int)range.Item1 + 1)
                         .Select(x => ((char)x).ToString()
    
        return r.Find().Where(s => letters.Contains(s.Name.Substring(0, 1)));
    }
