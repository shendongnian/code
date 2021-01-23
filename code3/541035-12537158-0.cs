    ConcurrentDictionary<User, string> dict = new ConcurrentDictionary<User, string>();
    dict.TryAdd(new User() { Context = "a", Ownder = false }, "aa");
    dict.TryAdd(new User() { Context = "b", Ownder = false }, "bb");
    dict.TryAdd(new User() { Context = "c", Ownder = true }, "cc");
    dict.TryAdd(new User() { Context = "d", Ownder = false }, "dd");
    IEnumerable<User> list = dict.Keys.Where(p => p.Context == "a");
