    ConcurrentDictionary<int, int> dictionary = new ConcurrentDictionary<int, int>();
    // Seed the dictionary with some arbitrary values; 
    for (int i = 0; i < 30; i++)
	{
        dictionary.TryAdd(i, i);
	}
    // Reader thread - Enumerate the Values collection
    Task.Factory.StartNew(
            () =>
            {
                foreach (var item in dictionary.Values)
                {
                    Console.WriteLine("Item {0}: count: {1}", item, dictionary.Count);
                    Thread.Sleep(20);
                }
            }
    );
    // writer thread - Modify dictionary by adding new items and removing existing ones from the end
    Task.Factory.StartNew(
            () =>
            {
                for (int i = 29; i >= 0; i--)
                {
                    Thread.Sleep(10);
                    //Remove an existing entry 
                    int removedValue;
                    if (dictionary.TryRemove(i, out removedValue))
                        Console.WriteLine("Removed item {0}", removedValue);
                    else
                        Console.WriteLine("Did not remove item {0}", i);
                    int iVal = 50 + i*2;
                    dictionary[iVal] = iVal;
                    Thread.Sleep(10);
                    iVal++;
                    dictionary.TryAdd(iVal, iVal);
                }
            }
    );
    Console.ReadKey();
