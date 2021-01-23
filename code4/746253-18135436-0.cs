    /// <summary>Enforces that the calling thread has access to this <see cref="T:System.Windows.Threading.DispatcherObject" />.</summary>
		/// <exception cref="T:System.InvalidOperationException">the calling thread does not have access to this <see cref="T:System.Windows.Threading.DispatcherObject" />.</exception>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void VerifyAccess()
		{
			Dispatcher dispatcher = this._dispatcher;
			if (dispatcher != null)
			{
				dispatcher.VerifyAccess();
			}
		}
