    public IEnumerable FlattenedModel
    {
        get
        {
            return (from b in TheModel.InstanceOfClassA.DictionaryInA.Values
                    from c in b.DictionaryInB.Values
                    select new
                    {
                        PropertyA1 = TheModel.PropertyA1,
                        PropertyA2 = TheModel.PropertyA2,
                        PropertyB1 = b.PropertyB1,
                        PropertyB2 = b.PropertyB2,
                        PropertyC1 = c.PropertyC1,
                        PropertyC2 = c.PropertyC2
                    }).ToList();
        }
    }
