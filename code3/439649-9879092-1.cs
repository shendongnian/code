    private static void Main()
    {
        var mylist = new List<string> {"abc", "DEF", "GHI"};
        mylist.Should().EqualInsensitively(new[] {"AbC", "def", "GHI"})
          .And.NotContain(string.Empty); //Emaple of chaining
    }
