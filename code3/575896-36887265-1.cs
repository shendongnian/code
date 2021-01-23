    public List<SessionStateItemCollection> GetAllUserSessions() {
   
	List<Hashtable> hTables = new List<Hashtable>();
	PropertyInfo propInfo = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static);
	object CacheInternal = propInfo.GetValue(null, null);
	dynamic fieldInfo = CacheInternal.GetType().GetField("_caches", BindingFlags.NonPublic | BindingFlags.Instance);
	if (fieldInfo != null) {
		object[] _caches = (object[])fieldInfo.GetValue(CacheInternal);
		for (int i = 0; i <= _caches.Length - 1; i++) {
			Hashtable hTable = (Hashtable)_caches(i).GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_caches(i));
			hTables.Add(hTable);
		}
	} else {
		fieldInfo = CacheInternal.GetType().GetField("_cachesRefs", BindingFlags.NonPublic | BindingFlags.Instance);
		dynamic cacheRefs = fieldInfo.GetValue(CacheInternal);
		foreach (void cacheRef_loopVariable in cacheRefs) {
			cacheRef = cacheRef_loopVariable;
			dynamic target = cacheRef.Target;
			fieldInfo = target.GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance);
			Hashtable hTable = fieldInfo.GetValue(target);
			hTables.Add(hTable);
		}
	}
	List<SessionStateItemCollection> sessionlist = new List<SessionStateItemCollection>();
	foreach (void hTable_loopVariable in hTables) {
		hTable = hTable_loopVariable;
		foreach (DictionaryEntry entry in hTable) {
			object value = entry.Value.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry.Value, null);
			if (value.GetType().ToString() == "System.Web.SessionState.InProcSessionState") {
				SessionStateItemCollection sCollection = (SessionStateItemCollection)value.GetType().GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(value);
				if (sCollection != null)
					sessionlist.Add(sCollection);
			}
		}
	}
	return sessionlist;
}
