    item.Expect(i => i.SetValues(IsCalledWithCorrectPair()));
    // ... 
    private IDictionary<string, object> IsCalledWithCorrectPair()
    {
        return Arg<IDictionary<string, object>>.Matches(items =>
        {
            Assert.That(items.Count(), Is.EqualTo(1));
            Assert.That(items.First().Key, Is.EqualTo("Date");
            // ...
            return true;
        });
    }
            
