    public IEnumerable<string> Something
    {
        get
        {
            var x = this.GetCallerName();
            for (int i = 0; i < 5; i++)
            {
                yield return x;
            }
        }
    }
    private string GetCallerName([CallerMemberName] string caller = null)
    {
        return caller;
    }
