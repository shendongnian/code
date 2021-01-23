    public void Inferred()
    {
        C c = new C();
        var v = Factory.Create(c, c); // type is Tuple<C, Other<string>>
    }
