    var dict =
        new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "F1", new Dictionary<string, string>
                                {
                                    {"F2", "foo"}
                                }
                    }
            };
    dict["F1"]["F2"] = "bar";
