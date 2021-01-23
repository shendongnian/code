    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void ExceptionThrown() {
        var list = new List<string>() {
            "Abel",
            "Baker",
            null,
            "Charlie"
        };
        var outer = new OuterClass(new Mock<InnerClass>().Object);
        outer.Koko(list);
    }
