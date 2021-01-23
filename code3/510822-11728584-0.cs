    public void Add(Isotope isotope, int count)
    {
        // I prefer early exit to lots of nesting :)
        if (count == 0)
        {
            return 0;
        }
        int newCount = _isotopes.AddOrUpdate(isotope, count, 
                                             (key, oldCount) => oldCount + count);
        if (newCount == 0)
        {
            _isotopes.Remove(isotope);
        }
        _isDirty = true;
    }
