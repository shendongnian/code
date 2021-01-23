    var original = new Dictionary<int, StringBuilder>();
    original[10] = new StringBuilder();
    var copy = new Dictoinary<int, StringBuilder>(original);
    copy[20] = new StringBuilder();
    // We have two different maps...
    Assert.IsFalse(original.ContainsKey(20));
    // But they both refer to a single StringBuilder in the entry for 10...
    copy[10].Append("Foo");
    Assert.AreEqual("Foo", original[10].ToString());
