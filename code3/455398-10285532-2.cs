    public bool GetSomeValueById(Guid innerId)
    {
        using (var a = SomeFactory.GetA(_uri))
        using (var b = a.GetB(_id))
        using (var c = b.GetC(innerId))
        {
            return c.GetSomeValue();
        }
    }
