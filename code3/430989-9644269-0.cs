    [Test]
    public void RegExWorks()
    {
       var regex = new Regex("\\b[A-C]{3}");
       Match match = regex.Match("ABC");
       Assert.IsTrue(match.Success); 
    }
