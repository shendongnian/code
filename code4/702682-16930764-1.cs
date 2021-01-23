    public IEnumerable<T> FindCommon<T>(IEnumerable<IEnumerable<T>> lists)
    {
        var listCount = lists.Count();
        return lists.SelectMany(x => x)
                    .GroupBy(x => x)
                    .Where(g => g.Count() == listCount);
    }
