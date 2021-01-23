	ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
	//..
	public string GetOrAdd(string name)
	{
		locker.EnterUpgradeableReadLock();
		try
		{
			if(!dictionary.ContainsKey(name))
			{
				locker.EnterWriteLock();
				try
				{
					dictionary[name] = new foo();
				}
				finally
				{
				locker.ExitWriteLock();
				}
			}
			value = dictionary[name];
		}
		finally
		{
			locker.ExitUpgradeableReadLock();
		}
		return value;
	}
