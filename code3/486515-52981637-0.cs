        private static void SaveProcessedFile(IEnumerable<HashedRow> processedRows, IEnumerable<HashedRow> justProcessedRows)
        {
            var comparer = new HashedRowEqualityComparerOrderLine();
            var updated = justProcessedRows.Join(processedRows, n => n, o => o, (n, o) => { o = n; return n; }, comparer); // n - new, o - old
            var inserted = justProcessedRows.Except(updated, comparer);
            // To do something
        }
