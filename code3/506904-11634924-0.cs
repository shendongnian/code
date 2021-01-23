    for (int i = 0; i < list.Count; i += 3) {
        var dict = new Dictionary<string, string>() {
            { "name", list[i] },
            { "gender", list[i+1] },
            { "country", list[i+2] }
        };
        dlist.Add(dict);
    }
