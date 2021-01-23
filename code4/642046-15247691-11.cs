    [TestMethod]
    public void TestForEachMethod()
    {
        // Create the list.
        List<MyObject> list = CreateList(ItemsToTest);
    
        // Create the writer.
        using (TextWriter writer = CreateNullTextWriter())
        {
            // Create the stopwatch.
            Stopwatch s = Stopwatch.StartNew();
    
            // Cycle through the items.
            list.ForEach(i => MyObjectAction(i, writer));
    
            // Write out the number of ticks.
            Debug.WriteLine("ForEach method ticks: {0}", s.ElapsedTicks);
        }
    }
