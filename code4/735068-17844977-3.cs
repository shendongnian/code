    public void MyKeyValuePairCaseInsensitiveKeyComparisonWorksCorrectly()
    {
        var x = new MyKeyValuePair("testvalue", 5);
        var y = new MyKeyValuePair("testvalue", 6);
        var z = new MyKeyValuePair("testvalue", 7);
        Assert.True(x == x, "== identity");
        Assert.True((x == y) == (y == x), "equals commutative");
        Assert.True(x == y, "== if x == y");
        Assert.True(y == x, "== and y == z");
        Assert.True(x == z, "== then x equals z");
        for (var successive_invocations = 0; successive_invocations < 3; successive_invocations++)
        {
            Assert.True(x == y, "== successive invocations");
        }
        Assert.False(x == null);
        Assert.True(x.Equals(x), "equals identity");
        Assert.True(x.Equals(y) == y.Equals(x), "equals commutative");
        Assert.True(x.Equals(y), "equals if x == y");
        Assert.True(y.Equals(x), "equals and y == z");
        Assert.True(x.Equals(z), "equals then x equals z");
        for (var successive_invocations = 0; successive_invocations < 3; successive_invocations++)
        {
            Assert.True(x.Equals(y), "equals successive invocations");
        }
        Assert.False(x.Equals(null));
        // show correct behavior
        var capi = "I";
        var lowi = "i";
        var capti = "İ";
        var lowti = "ı";
        Assert.True(capi.Equals(lowi, StringComparison.OrdinalIgnoreCase), "capi == lowi");
        Assert.False(capi.Equals(capti, StringComparison.OrdinalIgnoreCase), "capi != capti");
        Assert.False(capi.Equals(lowti, StringComparison.OrdinalIgnoreCase), "capi != lowti");
        Assert.False(lowi.Equals(capti, StringComparison.OrdinalIgnoreCase), "lowi != capti");
        Assert.False(lowi.Equals(lowti, StringComparison.OrdinalIgnoreCase), "lowi != lowti");
        Assert.False(capti.Equals(lowti, StringComparison.OrdinalIgnoreCase), "capti != lowti");
        //test actual behavior
        var a = new MyKeyValuePair(capi, 1);
        var b = new MyKeyValuePair(lowi, 2);
        var c = new MyKeyValuePair(capti, 3);
        var d = new MyKeyValuePair(lowti, 4);
        Assert.True(a.Equals(b), "a == b");
        Assert.False(a.Equals(c), "a != c");
        Assert.False(a.Equals(d), "a != d");
        Assert.False(b.Equals(c), "b != c");
        Assert.False(b.Equals(d), "b != d");
        Assert.False(c.Equals(d), "c != d");
    }
