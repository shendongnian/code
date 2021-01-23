    [Test]
    public void ObservableTest()
    {
        var observable = new ObservableCollection<string>{ "A", "B", "C", "D", "E"}; 
        
        observable.Move(1, 3); // oldIndex < newIndex 
        // Move "B" to "D"'s place: "C" and "D" are shifted left
        CollectionAssert.AreEqual(new[]{"A", "C", "D", "B", "E"}, observable);
        
        observable.Move(3, 1); // oldIndex > newIndex 
        // Move "B" to "C"'s place: "C" and "D" are shifted right
        CollectionAssert.AreEqual(new[] { "A", "B", "C", "D", "E" }, observable);
        
        observable.Move(1, 1); // oldIndex = newIndex
        // Move "B" to "B"'s place: "nothing" happens
        CollectionAssert.AreEqual(new[] { "A", "B", "C", "D", "E" }, observable);
    }
