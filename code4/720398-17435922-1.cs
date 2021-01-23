        private void DoStuff()
        {
            int maxSize = 89478457;
                //89000000;
            Console.WriteLine("Max size = {0:N0}", maxSize);
            var startMem = GC.GetTotalMemory(true);
            Console.WriteLine("Starting memory = {0:N0}", startMem);
            // Initialize a List<long> to hold maxSize items
            var l = new List<uint>(maxSize);
            // now add items to the list
            for (uint i = 0; i < maxSize; i++)
            {
                if ((i % 1000000) == 0)
                {
                    Console.Write("\r{0:N0}", i);
                }
                l.Add(i);
            }
            Console.WriteLine();
            var memAfterListAlloc = GC.GetTotalMemory(true);
            Console.WriteLine("After list populated = {0:N0}", memAfterListAlloc);
            // Construct a HashSet from that list
            var h = new HashSet<uint>(l);
            Console.WriteLine("{0:N0} items in the HashSet", h.Count);
            var memAfterHashAlloc = GC.GetTotalMemory(true);
            Console.WriteLine("After HashSet populated = {0:N0}", memAfterHashAlloc);
            var listMem = memAfterListAlloc - startMem;
            var hashMem = memAfterHashAlloc - memAfterListAlloc;
            Console.WriteLine("List occupies {0:N0}", listMem);
            Console.WriteLine("HashSet occupies {0:N0}", hashMem);
            Console.WriteLine("HashSet occupies {0:N2} times the memory of List", (double)hashMem / listMem);
            GC.KeepAlive(l);
            GC.KeepAlive(h);
            Console.Write("Press Enter:");
            Console.ReadLine();
        }
