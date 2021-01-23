    class MultiKeyDict
    {
        Dictionary<object, object[]>[] indexesByKey;
        public MultiKeyDict(int nKeys)
        {
            indexesByKey = new Dictionary<object, object[]>[nKeys];
        }
        public void Add(params object[] values)
        {
            if (values.Length != indexesByKey.Length)
                throw new ArgumentException("Wrong number of arguments given");
            var objects = values.ToArray();
            for (int i = 0; i < indexesByKey.Length; i++)
                this.indexesByKey[i].Add(values[i], objects);
        }
        public object[] Get(int keyNum, object key)
        {
            return this.indexesByKey[keyNum][key];
        }
    }
