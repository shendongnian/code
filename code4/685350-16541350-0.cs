    class Downloader
    {
        private IDictionary<string, string> _map;
        private IDictionary<string, string> _storage = new ConcurrentDictionary<string, string>();
        private ConcurrentDictionary<string, Task<string>> _progress = new ConcurrentDictionary<string,Task<string>>();
        public Downloader(IDictionary<string, string> map)
        {
            _map = map ?? new Dictionary<string, string>();
        }
        public async Task<string> Get(string key)
        {
            string path;
            if (!_map.TryGetValue(key, out path))
            {
                throw new ArgumentException("The specified key wasn't found");
            }
            if (_storage.ContainsKey(key))
            {
                return _storage[key];
            }
            Task<string> task;
            if (_progress.TryGetValue(key, out task))
            {
                return await task;
            }
            task = _retrieveFile(path);
            if (!_progress.TryAdd(key, task))
            {
                return await Get(key);
            }
            _storage[key] = await task;
            return _storage[key];
        }
        private async Task<string> _retrieveFile(string path)
        {
            Console.WriteLine("Started retrieving {0}", path);
            await Task.Delay(3000);
            Console.WriteLine("Finished retrieving {0}", path);
            return path + " local path";
            
        }
    }
