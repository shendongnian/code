        private readonly ISolrOperations<Document> _solr;
        private readonly ISolrConnection _solrConnection;
        public SolrRecordRepository(ISolrOperations<Document> solr, ISolrConnection solrConnection)
        {
            _solr = solr;
            _solrConnection = solrConnection;
        }
...
        public void UpdateField(int id, string fieldName, int value, bool optimize = false)
        {
            var updateXml = string.Format("<add><doc><field name='id'>{0}</field><field name='{1}' update='set'>{2}</field></doc></add>", id, fieldName, value);
            _solrConnection.Post("/update", updateXml);
            _solr.Commit();
            if (optimize)
                _solr.Optimize();
        }
