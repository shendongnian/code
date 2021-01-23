    [Test]
    public ShouldRaiseNaughtyErrorWhenDoBadly()
    {
        var logic = new MyClass();
        List<string> errorMessages = new List<string>();
        logic.DisplayError += delegate(string s) { errorMessages.Add(s); };    
    
        logic.DoItBadly();
    
        Assert.That(errorMessages.Contains("Naughty"));
    }
