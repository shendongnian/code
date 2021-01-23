    public string ToAssertableString(IDictionary<string,List<string>> dictionary) {
        var pairStrings = dictionary.OrderBy(p => p.Key)
                                    .Select(p => p.Key + ": " + string.Join(", ", p.Value));
        return string.Join("; ", pairStrings);
    }
    // ...
    Assert.AreEqual(ToAssertableString(dictionary1), ToAssertableString(dictionary2));
