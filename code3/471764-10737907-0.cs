    using System;
    using System.Threading;
    namespace Utils
    {
	public class ReaderWriterLockSlim2
	{
		#region Attributes
		private readonly TimeSpan _maxWait;
		private readonly ReaderWriterLockSlim _lock;
		#endregion
		#region Properties
		public int CurrentWriteOwnerId { get; private set; }
		public string CurrentWriteOwnerName { get; private set; }
		#endregion
		#region Public Methods
		public ReaderWriterLockSlim2(LockRecursionPolicy policy, TimeSpan maxWait)
		{
			_maxWait = maxWait;
			_lock = new ReaderWriterLockSlim(policy);
		}
		public void EnterWriteLock()
		{
			if (!_lock.TryEnterWriteLock(_maxWait))
			{
				throw new TimeoutException(string.Format("Timeout while waiting to enter a WriteLock. Lock adquired by Id {0} - Name {1}", this.CurrentWriteOwnerId, this.CurrentWriteOwnerName));
			}
			else
			{
				this.CurrentWriteOwnerId = Thread.CurrentThread.ManagedThreadId;
				this.CurrentWriteOwnerName = Thread.CurrentThread.Name;	
			}
		}
		public void ExitWriteLock()
		{
			_lock.ExitWriteLock();
			this.CurrentWriteOwnerId = 0;
			this.CurrentWriteOwnerName = null;	
		}
		public void EnterReadLock()
		{
			_lock.EnterReadLock();
		}
		public void ExitReadLock()
		{
			_lock.ExitReadLock();
		}
		#endregion
	}
    }
