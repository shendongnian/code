		public long Length
		{
			[SecuritySafeCritical]
			get
			{
				if (this._dataInitialised == -1)
				{
					base.Refresh();
				}
				if (this._dataInitialised != 0)
				{
					__Error.WinIOError(this._dataInitialised, base.DisplayPath);
				}
				if ((this._data.fileAttributes & 16) != 0)
				{
					__Error.WinIOError(2, base.DisplayPath);
				}
				return (long)this._data.fileSizeHigh << 32 | ((long)this._data.fileSizeLow & (long)((ulong)-1));
			}
		}
