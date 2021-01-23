        public class CachingObjectHolder
        {
            public readonly List<byte[]> Partials;
            public readonly List<CachingObject> CachingObjects;
            public readonly string CacheName;
    
            public CachingObjectHolder(string name, List<byte[]> partialList)
            {
                Partials = partialList;
                CacheName = name;
                CachingObjects = new List<CachingObject>();
                CreateCachingObjects();
            }
    
            private void CreateCachingObjects()
            {
                for (int i = 0; i < Partials.Count; i++)
                {
                    CachingObjects.Add(new CachingObject(string.Format("{0}_{1}", CacheName, i), i));
                }
            }
        }
    
        public class CachingObject
        {
            public int Index { get; set; }
            public string Name { get; set; }
    
            public CachingObject(string name, int index)
            {
                Index = index;
                Name = name;
            }
        }
