    public static System.Collections.Generic.IEnumerable<SessionStateItemCollection> GetAllUserSessions()
    {
        List<Hashtable> hTables = new List<Hashtable>();
        object obj = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);
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
                    SessionStateItemCollection sess = (SessionStateItemCollection)o1.GetType().GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(o1);
					if (sess != null)
						 yield return sess;
                }
            }
        }
    }
