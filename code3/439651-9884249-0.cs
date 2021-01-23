    [TestMethod()] 
    public void foo() 
    { 
       var actual = new List<string> { "ONE", "TWO", "THREE", "FOUR" }; 
       var expected = new List<string> { "One", "Two", "Three", "Four" }; 
 
      actual.Should().Equal(expected, 
        (o1, o2) => string.Compare(o1, o2, StringComparison.InvariantCultureIgnoreCase))
    } 
