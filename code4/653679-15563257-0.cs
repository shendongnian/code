     [Test]
     public void SplitStringByString()
     {
        string input = "abc; def; ghi";
        string[] expected = new[] {"abc", "def", "ghi"};
        var result = input.Split(new [] { "; " }, StringSplitOptions.None);
        Assert.That(result, Is.EquivalentTo(expected));
     }
