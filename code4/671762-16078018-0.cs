    string input = "a:b,c";
    int colon = input.IndexOf(':');
    string left = input.Substring(0, colon);
    string right = input.Substring(colon + 1);
    List<MyClass> result = right.Split(',')
                                .Select(x => new MyClass
                                {
                                    Column1 = left,
                                    Column2 = x,
                                })
                                .ToList();
