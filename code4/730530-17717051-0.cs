       //NO STATIC
        ...
        private Logger LogFile { get { return Logger.GetMethodLogger(2); } }   
        private Dictionary<string, NetObject> netObjectHashTable;
        private Dictionary<string, NetTitle> titlePropertyHashTable;
        private Dictionary<string, NetObject> referenceDataHashTable;
        private Dictionary<int, SortedDictionary<string, int>> picklistHashTable;
