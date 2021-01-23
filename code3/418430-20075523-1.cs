        var dictionary = new SortedDictionary<PrerenderedTemplate, string>(new PrerenderedTemplate.Comparer());
        dictionary.Add(new PrerenderedTemplate("1", "2", "3"), "123");
        dictionary.Add(new PrerenderedTemplate("4", "5", "6"), "456");
        dictionary.Add(new PrerenderedTemplate("7", "8", "9"), "789");
        Assert.AreEqual<string>(dictionary[new PrerenderedTemplate("7", "8", "9")], "789");
