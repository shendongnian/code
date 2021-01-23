    List<MyClass> batch = new List<MyClass>();
    int i = 0;
    foreach (MyClass item in items)
    {
        i++;
        batch.Add(item);
    
        if (i == 1000)
        {
            // Perform operation on batch
            batch.Clear();
            i = 0;
        }
    }
    
    // Process last batch
    if (i != 0)
    {
        // Perform operation on batch
    }
