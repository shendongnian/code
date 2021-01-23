        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int noOfItemsPerBatch)
        {
            decimal iterations = items.Count() / noOfItemsPerBatch;
            var roundedIterations = (int)Math.Ceiling(iterations);
            var batches = new List<IEnumerable<T>>();
            for (int i = 0; i < roundedIterations; i++)
            {
                var newBatch = items.Skip(i * noOfItemsPerBatch).Take(noOfItemsPerBatch).ToArray();
                batches.Add(newBatch);
            }
            return batches;
        }
