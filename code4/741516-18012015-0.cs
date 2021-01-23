    var objects = keyValuePairList
        .Aggregate<KeyValuePair<string, int>, List<CommonBase>>(
            new List<CommonBase>(), (a, p) =>
                {
                    CommonBase cObject;
                    if (p.Key == "N")
                    {
                        cObject = new NObject();
                        a.Add(cObject);
                    }
                    if (a.Count == 0)
                    {
                        cObject = new PObject();
                        var propertyInfo = typeof(PObject).GetProperty(p.Key);
                        propertyInfo
                            .SetValue(cObject, 
                                (int)propertyInfo.GetValue(cObject) + p.Value);
                        a.Add(cObject);
                    }
                    else
                    {
                        cObject = a.Last();
                        var propertyInfo = typeof(PObject).GetProperty(p.Key);
                        propertyInfo
                            .SetValue(cObject, 
                                (int)propertyInfo.GetValue(cObject) + p.Value);
                    }
                    return a;
                });
