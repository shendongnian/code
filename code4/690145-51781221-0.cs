    class ThreadLockerByID<T>
	{
		Dictionary<T, lockerObject<T>> lockers = new Dictionary<T, lockerObject<T>>();
		public IDisposable AcquireLock(T ID)
		{
			lockerObject<T> locker;
			lock (lockers)
			{
				if (lockers.ContainsKey(ID))
				{
					locker = lockers[ID];
				}
				else
				{
					locker = new lockerObject<T>(this, ID);
					lockers.Add(ID, locker);
				}
				locker.counter++;
			}
			Monitor.Enter(locker);
			return locker;
		}
		protected void ReleaseLock(T ID)
		{
			lock (lockers)
			{
				if (!lockers.ContainsKey(ID))
					return;
				var locker = lockers[ID];
				locker.counter--;
				if (Monitor.IsEntered(locker))
					Monitor.Exit(locker);
				if (locker.counter == 0)
					lockers.Remove(locker.id);
			}
		}
		class lockerObject<T> : IDisposable
		{
			readonly ThreadLockerByID<T> parent;
			internal readonly T id;
			internal int counter = 0;
			public lockerObject(ThreadLockerByID<T> Parent, T ID)
			{
				parent = Parent;
				id = ID;
			}
			public void Dispose()
			{
				parent.ReleaseLock(id);
			}
		}
	}
