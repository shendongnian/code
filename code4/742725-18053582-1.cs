       public abstract class YOURCollector : WHATEVER_COLLECTOER_THAT_YOU_ARE_USING
        {
            public List<int> PurchasedBooks { get; set; }
            public int?[] bookIds;
            public override void SetNextReader(IndexReader reader, int base_Renamed)
            {
                docBase = base_Renamed;
                bookIds = SingleFieldCache.Default.GetInt32s(reader, "BookId");
            }
            public override void Collect(int doc)
            {
                if (bookIds[doc].HasValue
                    && PurchasedBooks.Contains(bookIds[doc].Value) == false)
                {
                    base.Collect(doc);
                }
                else
                {
                    // book already purchased...
                }
            }
        }
