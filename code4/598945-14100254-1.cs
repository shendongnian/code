	public void Exit(object key) {
		if(!IsActive) {
			return;
		}
		if(LockDictionary.ContainsKey(key)) {
			var syncObject=LockDictionary[key];
			if(Monitor.TryEnter(syncObject.SyncObject, 0)) {
				SetLockExit(syncObject);
				Monitor.Exit(syncObject.SyncObject);
				Monitor.Exit(syncObject.SyncObject);
			}
		}
	}
