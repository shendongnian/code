		private static readonly Dictionary<string, XmlDocument> _cache = new Dictionary<string, XmlDocument>();
		private static readonly object _syncLock = new object();
		static private XmlDocument ReadFromFile(string siteID, Type stuffType)
		{
			string fsPath = FileSystemPath(siteID, stuffType.Name);
			XmlDocument cacheItem;
			lock (_syncLock)
			{
				if (!_cache.TryGetValue(fsPath, out cacheItem))
				{
					cacheItem = new XmlDocument();
					cacheItem.Load(fsPath);
					_cache[fsPath] = cacheItem;
				}
			}
			return (XmlDocument)cacheItem.Clone();
		}
		static private void WriteToFile(string siteID, XmlDocument stuff, string fileName)
		{
			string fsPath = FileSystemPath(siteID, fileName);
			lock (_syncLock)
			{
				_cache[fsPath] = stuff;
				stuff.Save(fsPath);
			}
		}
