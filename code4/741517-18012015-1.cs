    var objects = keyValuePairList
        .Aggregate<KeyValuePair<string, dynamic>, List<CommonBase>>(
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
                        Process(p, ref cObject);
                        a.Add(cObject);
                    }
                    else
                    {
                        cObject = a.Last();
                        Process(p, ref cObject);
                    }
                    return a;
                });
