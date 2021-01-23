    [Test]
    public void IsValidEntry_WithValidValues()
    {
        _selectedEntry = MakeEntry(_ticker);
        _entryValidator.OnInvalidEntry += delegate { 
            Assert.Fail("Shouldn't be called");
        };
        Assert.IsTrue(_entryValidator.IsValidEntry(_selectedEntry, _selectedEntry.Ticker));
    }    
    [Test]
    public void IsValidEntry_WithInValidTicker()
    {
        bool eventRaised = false;
        _selectedEntry = MakeEntry("");
        _entryValidator.OnInvalidEntry += delegate { eventRaised = true; };
        Assert.IsFalse(_entryValidator.IsValidEntry(_selectedEntry, _selectedEntry.Ticker));
        Assert.IsTrue(eventRaised);
    }
