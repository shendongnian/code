    [TestMethod]
    public void TestListIndexer()
    {
        // Create the list.
        List<MyObject> list = CreateList(ItemsToTest);
    
        // Create the writer.
        using (TextWriter writer = CreateNullTextWriter())
        {
            // Create the stopwatch.
            Stopwatch s = Stopwatch.StartNew();
    
            // Cycle by index.
            for (int i = 0; i < list.Count; ++i)
            {
                // Get the item.
                MyObject item = list[i];
    
                // Perform the action.
                MyObjectAction(item, writer);
            }
    
            // Write out the number of ticks.
            Debug.WriteLine("List indexer loop ticks: {0}", s.ElapsedTicks);
        }
    }
