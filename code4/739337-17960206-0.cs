    public List<T> InsertOrUpdate(List<T> items)
            {
                var subLists = SplitIntoPartitionedSublists(items);
    
                var tasks = new List<Task>();
    
                foreach (var subList in subLists)
                {
                    List<T> list = subList;
                    var task = Task.Factory.StartNew(() =>
                        {
                            var batchOp = new TableBatchOperation();
                            var tableRef = GetTableRef();
    
                            foreach (var item in list)
                            {
                                batchOp.Add(TableOperation.InsertOrReplace(item));
                            }
    
                            tableRef.ExecuteBatch(batchOp);
                            ReleaseTableRef(tableRef);
                        });
                    tasks.Add(task);
                }
    
                Task.WaitAll(tasks.ToArray());
    
                return items;
            }
    
    private IEnumerable<List<T>> SplitIntoPartitionedSublists(IEnumerable<T> items)
            {
                var itemsByPartion = new Dictionary<string, List<T>>();
    
                //split items into partitions
                foreach (var item in items)
                {
                    var partition = GetPartition(item);
                    if (itemsByPartion.ContainsKey(partition) == false)
                    {
                        itemsByPartion[partition] = new List<T>();
                    }
                    item.PartitionKey = partition;
                    item.ETag = "*";
                    itemsByPartion[partition].Add(item);
                }
    
                //split into subsets
                var subLists = new List<List<T>>();
                foreach (var partition in itemsByPartion.Keys)
                {
                    var partitionItems = itemsByPartion[partition];
                    for (int i = 0; i < partitionItems.Count; i += MaxBatch)
                    {
                        subLists.Add(partitionItems.Skip(i).Take(MaxBatch).ToList());
                    }
                }
    
                return subLists;
            }
    
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
    
            }
    
            private string GetPartition(T item)
            {
                var partKey = item.Id.ToString().Substring(34,2);
                return _partitionByKey[partKey];
            }
    
            private string GetPartition(Guid id)
            {
                var partKey = id.ToString().Substring(34, 2);
                return _partitionByKey[partKey];
            }
    
            private CloudTable GetTableRef()
            {
                CloudTable tableRef = null;
                //try to pop a table ref out of the stack
                var foundTableRefInStack = _tableRefs.TryPop(out tableRef);
                if (foundTableRefInStack == false)
                {
                    //no table ref available must create a new one
                    var client = _account.CreateCloudTableClient();
                    client.RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(1), 4);
                    tableRef = client.GetTableReference(_sTableName);
                }
    
                //ensure table is created
                if (_bTableCreated != true)
                {
                    tableRef.CreateIfNotExists();
                    _bTableCreated = true;
                }
    
                return tableRef;
            }
