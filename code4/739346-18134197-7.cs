    public class DyanmicBulkInsertTestPooledRefsAndAsynch : WebTest, IDynamicWebTest
    {
        private int _itemCount;
        private int _partitionCount;
        private int _batchSize;
        private List<TestTableEntity> _items;
        private GuidIdPartitionSplitter<TestTableEntity> _partitionSplitter;
        private string _tableName;
        private CloudStorageAccount _account;
        private CloudTableClient _tableClient;
        private Dictionary<string, List<TestTableEntity>> _itemsByParition;
        private int _maxRefCount;
        private BufferBlock<CloudTable> _tableRefs;
        public DyanmicBulkInsertTestPooledRefsAndAsynch()
        {
            Properties = new List<ItemProp>();    
            Properties.Add(new ItemProp("ItemCount", typeof(int)));
            Properties.Add(new ItemProp("PartitionCount", typeof(int)));
            Properties.Add(new ItemProp("BatchSize", typeof(int)));
            Properties.Add(new ItemProp("MaxRefs", typeof(int)));
            
        }
        public List<ItemProp> Properties { get; set; }
        public void SetProps(Dictionary<string, object> propValuesByPropName)
        {
            _itemCount = (int)propValuesByPropName["ItemCount"];
            _partitionCount = (int)propValuesByPropName["PartitionCount"];
            _batchSize = (int)propValuesByPropName["BatchSize"];
            _maxRefCount = (int)propValuesByPropName["MaxRefs"];
        }
        protected override void SetupTest()
        {
            base.SetupTest();
            ThreadPool.SetMinThreads(1024, 256);
            ServicePointManager.DefaultConnectionLimit = 256;
            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.Expect100Continue = false;
            _account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString"));
            _tableClient = _account.CreateCloudTableClient();
            _tableName = "testtable" + new Random().Next(100000);
            //create the refs
            _tableRefs = new BufferBlock<CloudTable>();
            for (int i = 0; i < _maxRefCount; i++)
            {
                _tableRefs.Post(_tableClient.GetTableReference(_tableName));
            }
            var tableRefTask = GetTableRef();
            tableRefTask.Wait();
            var tableRef = tableRefTask.Result;
            tableRef.CreateIfNotExists();
            ReleaseRef(tableRef);
            _items = TestUtils.GenerateTableItems(_itemCount);
            _partitionSplitter = new GuidIdPartitionSplitter<TestTableEntity>();
            _partitionSplitter.BuildPartitions(_partitionCount);
            _items.ForEach(o =>
                {
                    o.ETag = "*";
                    o.Timestamp = DateTime.Now;
                    o.PartitionKey = _partitionSplitter.GetPartition(o);
                });
            _itemsByParition = _partitionSplitter.SplitIntoPartitionedSublists(_items);
        }
        private async Task<CloudTable> GetTableRef()
        {
            return await _tableRefs.ReceiveAsync();            
        }
        private void ReleaseRef(CloudTable tableRef)
        {
            _tableRefs.Post(tableRef);
        }
        protected override void ExecuteTest()
        {
            Task.WaitAll(_itemsByParition.Keys.Select(parition => Task.Factory.StartNew(() => InsertParitionItems(_itemsByParition[parition]))).ToArray());
        }
        private void InsertParitionItems(List<TestTableEntity> items)
        {
            
            var tasks = new List<Task>();
            for (int i = 0; i < items.Count; i += _batchSize)
            {
                int i1 = i;
                var task = Task.Factory.StartNew(async () =>
                {
                    var batchItems = items.Skip(i1).Take(_batchSize).ToList();
                        
                    if (batchItems.Select(o => o.PartitionKey).Distinct().Count() > 1)
                    {
                        throw new Exception("Multiple partitions batch");
                    }
                    var batchOp = new TableBatchOperation();
                    batchItems.ForEach(batchOp.InsertOrReplace);   
                    
                    var tableRef = GetTableRef.Result();
                    tableRef.ExecuteBatch(batchOp);
                    ReleaseRef(tableRef);
                });
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            
            
        }
        protected override void CleanupTest()
        {
            var tableRefTask = GetTableRef();
            tableRefTask.Wait();
            var tableRef = tableRefTask.Result;
            tableRef.DeleteIfExists();
            ReleaseRef(tableRef);
        }
