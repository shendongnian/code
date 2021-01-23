    public List<List<IGrid>> Separat(List<IGrid> source) {
        return source
            .GroupBy(s => s.RowIndex)
            .OrderBy(g => g.Key)
            .Select(g => g.ToList())
            .ToList();
    }
