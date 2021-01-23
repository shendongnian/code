        public static BlockingCollection<Bar> Merge(IEnumerable<BlockingCollection<Bar>> collections)
        {
            BlockingCollection<Bar> masterCollection = new BlockingCollection<Bar>();
            LinkedList<BarWrapper> orderedLows = new LinkedList<BarWrapper>();
            foreach (var c in collections)
                OrderedInsert(new BarWrapper { Value = c.Take(), Source = c }, orderedLows);
            while (orderedLows.Any())
            {
                BarWrapper currentLow = orderedLows.First.Value;
                orderedLows.RemoveFirst();
                BlockingCollection<Bar> collection = currentLow.Source;
                if (collection.Any())
                    OrderedInsert(new BarWrapper { Value = collection.Take(), Source = collection }, orderedLows);
                masterCollection.Add(currentLow.Value);
            }
            return masterCollection;
        }
        private static void OrderedInsert(BarWrapper bar, LinkedList<BarWrapper> orderedLows)
        {
            if (!orderedLows.Any())
            {
                orderedLows.AddFirst(bar);
                return;
            }
            var iterator = orderedLows.First;
            while (iterator != null && iterator.Value.Value.LongValue < bar.Value.LongValue)
                iterator = iterator.Next;
            if (iterator == null)
                orderedLows.AddLast(bar);
            else
                orderedLows.AddBefore(iterator, bar);
        }
        class BarWrapper
        {
            public Bar Value { get; set; }
            public BlockingCollection<Bar> Source { get; set; }
        }
        class Bar
        {
            public Bar(long l)
            {
                this.LongValue = l;
            }
            public long LongValue { get; set; }
        }
