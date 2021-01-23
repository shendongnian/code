    public void UpdateFromXml(Guid innerId, XDocument someXml)
    {
        var a = SomeFactory.GetA(_uri);
        var b = a.GetB(_id);
        var c = b.GetC(innerId);
        using(new CompositeDisposable(a,b,c))
        {
            var cWrapper = new SomeWrapper(c);
            cWrapper.Update(someXml);
        }
    }
