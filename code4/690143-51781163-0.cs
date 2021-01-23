    class ThreadLocker
	{
		const int DEFAULT_LOCKERS_COUNTER = 997;
		int lockersCount;
		object[] lockers;
		public ThreadLocker(int MaxLockersCount)
		{
			if (MaxLockersCount < 1) throw new ArgumentOutOfRangeException("MaxLockersCount", MaxLockersCount, "Counter cannot be less, that 1");
			lockersCount = MaxLockersCount;
			lockers = Enumerable.Range(0, lockersCount).Select(_ => new object()).ToArray();
		}
		public ThreadLocker() : this(DEFAULT_LOCKERS_COUNTER) { }
		public object GetLocker(int ObjectID)
		{
			var idx = (ObjectID % lockersCount + lockersCount) % lockersCount;
			return lockers[idx];
		}
		public object GetLocker(string ObjectID)
		{
			var hash = ObjectID.GetHashCode();
			return GetLocker(hash);
		}
		public object GetLocker(Guid ObjectID)
		{
			var hash = ObjectID.GetHashCode();
			return GetLocker(hash);
		}
	}
