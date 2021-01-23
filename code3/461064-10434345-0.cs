        class Bar
        {
            public Bar(long l)
            {
                this.LongValue = l;
            }
            public long LongValue { get; set; }
        }
        public BlockingCollection<Bar> MergeSort(IEnumerable<BlockingCollection<Bar>> collections)
        {
            BlockingCollection<Bar> masterCollection = new BlockingCollection<Bar>();
            bool complete = ! collections.Any(c => c.Any());
            while (!complete)
            {
                long min = long.MaxValue;
                BlockingCollection<Bar> selectedCollection = null;
                foreach (var collection in collections.Where(c => c.Any()))
                {
                    if(collection.First().LongValue < min)
                    {
                        selectedCollection = collection;
                        min = collection.First().LongValue;
                    }
                }
                if (min == long.MaxValue)
                    complete = true;
                else
                    masterCollection.Add(selectedCollection.Take());
            }
         }
