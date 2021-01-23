     public class SimpleGuidIdPartitionSplitter<T> where T : IUniqueId
    {
        private ConcurrentDictionary<string, string> _partitionByKey = new ConcurrentDictionary<string, string>();
        private List<string> _partitions;
        private bool _bPartitionsBuilt;
        public SimpleGuidIdPartitionSplitter()
        {
            
        }
        public void BuildPartitions(int iPartCount)
        {
            BuildPartitionIndentifiers(iPartCount);
        }
        public string GetPartition(T item)
        {
            if (_bPartitionsBuilt == false)
            {
                throw new Exception("Partitions Not Built");
            }
            var partKey = item.Id.ToString().Substring(34, 2);
            return _partitionByKey[partKey];
        }
        public string GetPartition(Guid id)
        {
            if (_bPartitionsBuilt == false)
            {
                throw new Exception("Partitions Not Built");
            }
            var partKey = id.ToString().Substring(34, 2);
            return _partitionByKey[partKey];
        }
        #region Helpers
        private void BuildPartitionIndentifiers(int partitonCount)
        {
            var chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' }.ToList();
            var keys = new List<string>();
            for (int i = 0; i < chars.Count; i++)
            {
                var keyA = chars[i];
                for (int j = 0; j < chars.Count; j++)
                {
                    var keyB = chars[j];
                    keys.Add(string.Concat(keyA, keyB));
                }
            }
            var keySetMaxSize = Math.Max(1, (int)Math.Floor((double)keys.Count / ((double)partitonCount)));
            var keySets = new List<List<string>>();
            if (partitonCount > keys.Count)
            {
                partitonCount = keys.Count;
            }
            //Build the key sets
            var index = 0;
            while (index < keys.Count)
            {
                var keysSet = keys.Skip(index).Take(keySetMaxSize).ToList();
                keySets.Add(keysSet);
                index += keySetMaxSize;
            }
            //build the lookups and datatable for each key set
            _partitions = new List<string>();
            for (int i = 0; i < keySets.Count; i++)
            {
                var partitionName = String.Concat("subSet_", i);
                foreach (var key in keySets[i])
                {
                    _partitionByKey[key] = partitionName;
                }
                _partitions.Add(partitionName);
            }
            _bPartitionsBuilt = true;
        }
        #endregion
    }
    internal static List<TestTableEntity> GenerateTableItems(int count)
            {
                var items = new List<TestTableEntity>();
                var random = new Random();
    
                for (int i = 0; i < count; i++)
                {
                    var itemId = Guid.NewGuid();
    
                    items.Add(new TestTableEntity()
                    {
                        Id = itemId,
                        TestGuid = Guid.NewGuid(),
                        RowKey = itemId.ToString(),
                        TestBool = true,
                        TestDateTime = DateTime.Now,
                        TestDouble = random.Next() * 1000000,
                        TestInt = random.Next(10000),
                        TestString = Guid.NewGuid().ToString(),
                    });
                }
    
                var dupRowKeys = items.GroupBy(o => o.RowKey).Where(o => o.Count() > 1).Select(o => o.Key).ToList();
                if (dupRowKeys.Count > 0)
                {
                    throw  new Exception("Dupicate Row Keys");
                }
    
                return items;
            }
