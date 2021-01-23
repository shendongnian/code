    [TestMethod]
    public void TestForEachKeyword()
    {
        // Create the list.
        List<MyObject> list = CreateList(ItemsToTest);
    
        // Create the writer.
        using (TextWriter writer = CreateNullTextWriter())
        {
            // Create the stopwatch.
            Stopwatch s = Stopwatch.StartNew();
    
            // Cycle through the items.
            foreach (var item in list)
            {
                // Write the values.
                MyObjectAction(item, writer);
            }
    
            // Write out the number of ticks.
            Debug.WriteLine("Foreach loop ticks: {0}", s.ElapsedTicks);
        }
    }
