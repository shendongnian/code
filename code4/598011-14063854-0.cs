	public class SomeClass
	{
		private MemoryBlock block = new MemoryBlock(1024, 16);
		private ReaderWriterLockSlim blockSyncObjcect = new ReaderWriterLockSlim();
		public void SomeRead()
		{
			blockSyncObjcect.EnterReadLock();
			// Safe reading from the block
			blockSyncObjcect.ExitReadLock();
		}
		public void SomeWrite()
		{
			blockSyncObjcect.EnterWriteLock();
			// Safe writing to the block
			blockSyncObjcect.ExitWriteLock();
		}
	}
