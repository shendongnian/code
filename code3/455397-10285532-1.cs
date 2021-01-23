    public bool GetSomeValueById(Guid innerId)
    {
        using (var a = SomeFactory.GetA(_uri))
        {
            return a.GetSomeValue();
        }
    }
