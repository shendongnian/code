    [Test]
    public ShouldRaiseBothErrors()
    {
        var logic = new MyClass();
        List<string> errorMessages = new List<string>();
        logic.DisplayError += delegate(string s) {errorMessages.Add(s); };
    
        // do something for other problem condition
        logic.DoItBadly();
    
        Assert.That(errorMessages.Count, Is.EqualTo(2));
        Assert.That(errorMessage[0], Is.EqualTo("Naughty"));
        Assert.That(errorMessage[1], Is.EqualTo("Something else naughty"));
    }
