        public class Cache
        {
            private const string kFileListName = "FileList";
    
            public static DataCacheFactory DataCacheFactory
            {
                get
                {
                    return new DataCacheFactory();
                }
            }
    
            private static DataCache fDataCache;
            public static DataCache DataCache
            {
                get
                {
                    if(fDataCache == null)
                    {
                        fDataCache = DataCacheFactory.GetDefaultCache();
                    }
    
                    return fDataCache;
                }
            }
    
            public static byte[] Get(string name)
            {
                var dic = GetFileList();
                if (dic == null)
                {
                    return (byte[])DataCache.Get(name);
                }
                if (dic.ContainsKey(name))
                {
                    var list = dic[name];
                    var input = new List<byte[]>();
                    var cache = DataCache;
                    list = list.OrderBy(x => x.Item2).ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        input.Add(cache.Get(list[i].Item1) as byte[]);
                    }
    
                    var holder = new CachingObjectHolder(name, input);
                    return CacheHelper.Join(holder);
                }
                else
                {
                    return (byte[])DataCache.Get(name);
                }
            }
    
            public static void Put(string name, byte[] file)
            {
                if (file.Length > CacheHelper.kMaxFileSize)
                {
                    var helper = new CacheHelper(file.Length, name);
                    var output = helper.Split(file);
                    var dic = GetFileList();
                    if (dic == null)
                    {
                        dic = new Dictionary<string, List<Tuple<string, int>>>();
                    }
    
                    var partials = new List<Tuple<string, int>>();
                    for (int i = 0; i < output.CachingObjects.Count; i++)
                    {
                        DataCache.Add(output.CachingObjects[i].Name, output.Partials[output.CachingObjects[i].Index]);
                        partials.Add(new Tuple<string, int>(output.CachingObjects[i].Name, 
                                                   output.CachingObjects[i].Index));   
                    }
                                    
                    dic.Add(name, partials.OrderBy(x => x.Item2).ToList());
                    PutFileList(dic);
                }
                else
                {
                    DataCache.Add(name, file);
                }
            }
    
            public static void Remove(string name)
            {
                var dic = GetFileList();
                if (dic == null)
                {
                    DataCache.Remove(name);
                    return;
                }
    
                if (dic.ContainsKey(name))
                {
                    var list = dic[name];
                    for (int i = 0; i < list.Count; i++)
                    {
                        DataCache.Remove(list[i].Item1);
                    }
    
                    dic.Remove(name);
                    PutFileList(dic);
                }
                else
                {
                    DataCache.Remove(name);
                }
            }
    
            private static void PutFileList(Dictionary<string, List<Tuple<string, int>>> input)
            {
                DataCache.Put(kFileListName, input);
            }
    
            private static Dictionary<string, List<Tuple<string, int>>> GetFileList()
            {
                return DataCache.Get(kFileListName) as Dictionary<string, List<Tuple<string, int>>>;
            }
        }
