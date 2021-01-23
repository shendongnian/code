    private static const int N = 13;
    public string[] Data = new string[N];
    public List<string>[] Filter = new List<string>[N];
    //------------------------------------------------------------------------------
    for(int i = 0; i < N; i++)
    {
        if(filter.Filter[i] != null && filter.Filter[i].Any()) {
            data = data.Where(x => filter.Filter[i].Contains(x.Data[i]));
    }
