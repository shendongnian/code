    [TestMethod]
    public void TestArray()
    {
        // Create the list.
        MyObject[] array = CreateList(ItemsToTest).ToArray();
    
        // Create the writer.
        using (TextWriter writer = CreateNullTextWriter())
        {
            // Create the stopwatch.
            Stopwatch s = Stopwatch.StartNew();
    
            // Cycle by index.
            for (int i = 0; i < array.Length; ++i)
            {
                // Get the item.
                MyObject item = array[i];
    
                // Perform the action.
                MyObjectAction(item, writer);
            }
    
            // Write out the number of ticks.
            Debug.WriteLine("Enumerator loop ticks: {0}", s.ElapsedTicks);
        }
    }
