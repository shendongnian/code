		Dictionary<Tuple<int, int, int>, int> map1 = new Dictionary<Tuple<int, int, int>, int>();
        Dictionary<int, Dictionary<int, Dictionary<int, int>>> map2 = new Dictionary<int, Dictionary<int, Dictionary<int, int>>>();
       
        public void SizeTest()
        {
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    for (int z = 0; z < 600; z++)
                    {
                        addToMap1(x, y, z, 0);
                        addToMap2(x, y, z, 0);
                    }
                }
            }
            int size1 = GetObjectSize(map1);
            int size2 = GetObjectSize(map2);
            Console.WriteLine(size1);
            Console.WriteLine(size2);
        }
        private void addToMap1(int x, int y, int z, int value)
        {
            map1.Add(new Tuple<int, int, int>(x, y, z), value);
        }
        private void addToMap2(int x, int y, int z, int value)
        {
            map2.GetOrAdd(x, _ => new Dictionary<int, Dictionary<int, int>>())
                .GetOrAdd(y, _ => new Dictionary<int, int>())
                .GetOrAdd(z, _ => value);
        }
        private int GetObjectSize(object TestObject)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] Array;
            bf.Serialize(ms, TestObject);
            Array = ms.ToArray();
            return Array.Length;
        }
        public static TResult GetOrAdd<TKey, TResult>(this Dictionary<TKey, TResult> map, TKey key, Func<TKey, TResult> addIfMissing)
        {
            TResult result;
            if (!map.TryGetValue(key, out result))
            {
                result = addIfMissing(key);
                map[key] = result;
            }
            return result;
        }
