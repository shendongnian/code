    private static void MeasureMemory()
    {
        int size = 10000000;
        object[] array = new object[size];
        
        long before = GC.GetTotalMemory(true);
        for (int i = 0; i < size; i++)            
        {
            array[i] = new Data();
        }
        long after = GC.GetTotalMemory(true);
        
        double diff = after - before;
        Console.WriteLine("Total bytes: " + diff);
        Console.WriteLine("Bytes per object: " + diff / size);
    }
