    // Note: the method is still generic!
    private void WriteGenericCollection<T>(object obj)
    {
        var casted = (IEnumerable<T>)obj;
    }
