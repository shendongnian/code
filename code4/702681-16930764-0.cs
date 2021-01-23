    public IEnumerable<T> FindUniques<T>(IEnumerable<IEnumerable<T>> lists)
    {
        return lists.SelectMany(x => x)
                    .GroupBy(x => x)
                    .Where(g => g.Count() == 1);
    }
