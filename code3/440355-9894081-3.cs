    [Test]
    public ShouldRaiseNaughtyErrorWhenDoBadly()
    {
        var logic = new MyClass();
        string errorMessage = String.Empty;
        logic.DisplayError += delegate(string s) {errorMessage = s; };
    
        logic.DoItBadly();
    
        Assert.That(errorMessage, Is.EqualTo("Naughty"));
    }
    
    [Test]
    public ShouldRaiseElseNaughtyErrorWhenDoBadlyWithOtherProblem()
    {
        var logic = new MyClass();
        string errorMessage = String.Empty;
        logic.DisplayError += delegate(string s) {errorMessage = s; };
    
        // do something for other problem condition
        logic.DoItBadly();
    
        Assert.That(errorMessage, Is.EqualTo("Something else naughty"));
    }
