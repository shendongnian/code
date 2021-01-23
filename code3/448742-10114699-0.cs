    public class Cache
    {
        private string cacheName;
        private Cache(string cacheName)
        {
            this.cacheName = cacheName;
        }
        public static async Cache GetCacheAsync(string cacheName)
        {
             Cache cache = new Cache(cacheName);
             
             await cache.Initialize();
             return cache;
        }
        private async void Initialize()    
        {   
                StorageFolder rootFolder = ApplicationData.Current.LocalFolder;   
                var _folder = await rootFolder.CreateFolderAsync(this.cacheName, CreationCollisionOption.OpenIfExists);   
                var file = await _folder.CreateFileAsync("test.xml", CreationCollisionOption.OpenIfExists);
       }
    }
