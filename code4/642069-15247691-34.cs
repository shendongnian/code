    [TestMethod]
    public void TestEnumerator()
    {
        // Create the list.
        List<MyObject> list = CreateList(ItemsToTest);
    
        // Create the writer.
        using (TextWriter writer = CreateNullTextWriter())
        // Get the enumerator.
        using (IEnumerator<MyObject> enumerator = list.GetEnumerator())
        {
            // Create the stopwatch.
            Stopwatch s = Stopwatch.StartNew();
    
            // Cycle through the items.
            while (enumerator.MoveNext())
            {
                // Write.
                MyObjectAction(enumerator.Current, writer);
            }
    
            // Write out the number of ticks.
            Debug.WriteLine("Enumerator loop ticks: {0}", s.ElapsedTicks);
        }
    }
