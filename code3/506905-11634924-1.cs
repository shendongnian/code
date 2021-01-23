    for (int i = 0; i < list.Count; i += 3) {
        dlist.Add(new Dictionary<string, string>() {
            { "name", (string)list[i] },
            { "gender", (string)list[i+1] },
            { "country", (string)list[i+2] }
        });
    }
