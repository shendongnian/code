    public NotificationServiceAccessor(ObjectWithEvent objectWithEvent)
    {
        _notificationService = new NotificationService();
        _notificationService.StatusChanged += NotificationService_StatusChanged; // Local object, no Dipose
        _objectWithEvent = objectWithEvent;
        _objectWithEvent.AnEvent += AnEventHandler(); // Event that has to be disposed.
    }
    	#region IDisposable Members
		protected bool Disposed { get; private set; }
		private void Dispose(bool disposing)
		{
			if (!this.Disposed)
			{
				this.InternalDispose(disposing);
			}
			this.Disposed = true;
		}
		protected virtual void InternalDispose(bool disposing)
		{
			if (disposing)
			{
                            // Dispose here the event handlers
                            _objectWithEvent.AnEvent -= AnEventHandler()
			}
			// Dispose here only unmanaged objects 
			// Don’t use managed objects here because maybe 
			// they have been finalized already
		}
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		~NotificationServiceAccessor()
		{
			this.Dispose(false);
		}
		#endregion
