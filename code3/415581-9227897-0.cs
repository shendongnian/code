        public class ExtendedCollector : Collector
        {
            private Scorer _scorer;
            private Int32 _docBase;
            private List<CollectedDocument> _documents;
            public ExtendedCollector()
            {
                _documents = new List<CollectedDocument>();
            }
            public override void SetScorer(Scorer scorer)
            {
                _scorer = scorer;
            }
            public override void Collect(int doc)
            {
                var docId = _docBase + doc;
                var score = _scorer.Score();
                var currentDoc = _documents.FirstOrDefault(d => d.DocId == docId);
                if (currentDoc == null)
                    _documents.Add(new CollectedDocument()
                                       {DocId = docId, Score = score, OriginalIndex = _documents.Count, Index = _documents.Count});
                else
                    currentDoc.Score = score;
            }
            public override void SetNextReader(IndexReader reader, int docBase)
            {
                _docBase = docBase;
            }
            public override bool AcceptsDocsOutOfOrder()
            {
                return false;
            }
            public List<CollectedDocument> Documents
            {
                get { return _documents; }
            }
            public List<CollectedDocument> DocumentsByScore
            {
                get
                {
                    var result = _documents.OrderByDescending(d => d.Score).ToList();
                    var itemId = 0;
                    foreach (var collectedDocument in result)
                    {
                        itemId++;
                        collectedDocument.Index = itemId;
                    }
                    return result;
                }
            }
        }
