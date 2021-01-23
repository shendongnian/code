    var dict = new Dictionary<string, Entity>();
    dict.Add("1;A", new Entity(1, "A"));
    Entity e;
    If (dict.TryGetValue("1;A", out e)) {
        Use(e);
    }
