            Console.Write("How many entries would you like to store in the Hashtable?:");
            int hashTableEntries;
            int.TryParse(Console.ReadLine(), out hashTableEntries);
            var memBeforeHashInit = GC.GetTotalMemory(true);
            var hashTable = new Hashtable();
            for (int i = 0; i < hashTableEntries; i++)
                hashTable.Add(i, i);
            var memAfterHashInit = GC.GetTotalMemory(false);
            var diff = memAfterHashInit - memBeforeHashInit;
            Console.WriteLine("Memory used since startup: {0} bytes" +
                "\r\n" +
                "Hashtable entries: {1}" +
                "\r\n" +
                "Press any key to exit", diff, hashTableEntries);
            Console.ReadLine();
