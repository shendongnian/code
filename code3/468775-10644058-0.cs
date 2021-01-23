    if (p is IEnumerable)
    {
        foreach (object o in p)
        {
            if (!o.HasPropertyChanged(...))
                return false;
        }
    }
