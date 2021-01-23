		// attempt to get Asp.Net internal cache
		// adapted from https://stackoverflow.com/a/46554310/1086134
		private static object getAspNetInternalCacheObj ()
		{
			object aspNetCacheInternal = null;
			PropertyInfo cacheInternalPropInfo = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static);
			if (cacheInternalPropInfo != null)
			{
				aspNetCacheInternal = cacheInternalPropInfo.GetValue(null, null);
				return aspNetCacheInternal;
			}
			// At some point, after some .NET Framework's security update, that internal member disappeared.
			// https://stackoverflow.com/a/45045160
			// 
			// We need to look for internal cache otherwise.
			//
			var cacheInternalFieldInfo = HttpRuntime.Cache.GetType().GetField("_internalCache", BindingFlags.NonPublic | BindingFlags.Static);
			if (cacheInternalFieldInfo == null)
				return null;
			
			var httpRuntimeInternalCache = cacheInternalFieldInfo.GetValue(HttpRuntime.Cache);
			var httpRuntimeInternalCacheField = httpRuntimeInternalCache.GetType().GetField("_cacheInternal", BindingFlags.NonPublic | BindingFlags.Instance);
			if (httpRuntimeInternalCacheField == null)
				return null;
			aspNetCacheInternal = httpRuntimeInternalCacheField.GetValue(httpRuntimeInternalCache);
			return aspNetCacheInternal;
		}
		// adapted from https://stackoverflow.com/a/39422431/1086134
		private static IEnumerable<System.Web.SessionState.SessionStateItemCollection> getAllUserSessions()
		{
			List<Hashtable> hTables = new List<Hashtable>();
			object obj = getAspNetInternalCacheObj();
			if (obj == null)
				yield break;
			dynamic fieldInfo = obj.GetType().GetField("_caches", BindingFlags.NonPublic | BindingFlags.Instance);
			//If server uses "_caches" to store session info
			if (fieldInfo != null)
			{
				object[] _caches = (object[])fieldInfo.GetValue(obj);
				for (int i = 0; i <= _caches.Length - 1; i++)
				{
					Hashtable hTable = (Hashtable)_caches[i].GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_caches[i]);
					hTables.Add(hTable);
				}
			}
			//If server uses "_cachesRefs" to store session info
			else
			{
				fieldInfo = obj.GetType().GetField("_cachesRefs", BindingFlags.NonPublic | BindingFlags.Instance);
				object[] cacheRefs = fieldInfo.GetValue(obj);
				for (int i = 0; i <= cacheRefs.Length - 1; i++)
				{
					var target = cacheRefs[i].GetType().GetProperty("Target").GetValue(cacheRefs[i], null);
					Hashtable hTable = (Hashtable)target.GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);
					hTables.Add(hTable);
				}
			}
			foreach (Hashtable hTable in hTables)
			{
				foreach (DictionaryEntry entry in hTable)
				{
					object o1 = entry.Value.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry.Value, null);
					if (o1.GetType().ToString() == "System.Web.SessionState.InProcSessionState")
					{
						System.Web.SessionState.SessionStateItemCollection sess = (System.Web.SessionState.SessionStateItemCollection)o1.GetType().GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(o1);
						if (sess != null)
							yield return sess;
					}
				}
			}
		}
