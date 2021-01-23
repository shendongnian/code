        const int AllocSize = 64;            // 64 kb block
        const int MaxBudget = 5 * 1024;      // Test max to 5 mb
        static int GetG0Budget()
        {
            GC.Collect(0, GCCollectionMode.Forced, true);
            int gcCount = GC.CollectionCount(0);
            int sum = 0;
            for (int i = 0; i < MaxBudget; i += AllocSize)
            {
                byte[] buffer = new byte[AllocSize * 1024];
                sum += buffer[0];
                if (GC.CollectionCount(0) != gcCount)
                {
                    return i;
                }
            }
            return MaxBudget + sum;
        }
