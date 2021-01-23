        private static Dictionary<string, InstrumentTransformer> InitInstrumentTransformers()
        {
            var result = new Dictionary<string, InstrumentTransformer>();
            using (var adapter = new _TSTAT_SETUPDataSetTableAdapters.SetupInstrumentTransformersTableAdapter())
            {
                var table = adapter.GetData();
                foreach (var row in table)
                {
                    var instrumentTransformer = new InstrumentTransformer(row);
                    result[instrumentTransformer.TransformerID] = instrumentTransformer;
                }
            }
            return result;
        }
