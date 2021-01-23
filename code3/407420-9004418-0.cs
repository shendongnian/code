     var data = new List<String>();
                data.BreakIntoChunks(3).Select(html => string.Format("<div>{0}</div>", String.Join("", (html.Select(
                    item => string.Format("<a>{0}</a>", item))).ToArray())));
            ...
    
        public static class EnumerableExt
        {
            public static IEnumerable<IEnumerable<TRecord>> BreakIntoChunks<TRecord>(this IEnumerable<TRecord> items,
                                                                                     int chunkSize)
            {
                int itemCount = 0;
                var processedItems = new List<TRecord>();
                foreach (TRecord record in items)
                {
                    ++itemCount;
                    processedItems.Add(record);
                    if (itemCount%chunkSize == 0)
                    {
                        yield return processedItems;
                        processedItems.Clear();
                    }
                }
                if (processedItems.Count != 0)
                {
                    //Because- return the items which are not multiple of chunkSize
                    yield return processedItems;
                }
            }
        }
