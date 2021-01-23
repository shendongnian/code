    private ICollection<MyCoolClass> _someCollection
    public void DeleteAndSetNext(IEnumerable<MyCoolClass> IEDelete)
    {
        bool boolStop = false;
        MyCoolClass NewCurrent = _someCollection.FirstOrDefault(a =>
            {
                if (!boolStop) boolStop = IEDelete.Contains(a);
                return boolStop && !IEDelete.Contains(a);
            });
        foreach (MyCoolClass cl in IEDelete)
        {
            _someCollection.Remove(a);
        }
        CurrentMyCoolClass = NewCurrent ?? _someCollection.LastOrDefault();
    }
    MyCoolClass CurrentMyCoolClass
    {
        get;
        set;
    }
