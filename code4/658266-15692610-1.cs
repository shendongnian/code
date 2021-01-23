	public void RefreshSessions()
	{
		if (_SessionEnum != null)
		{
			Marshal.ReleaseComObject(_SessionEnum);
		}
		Marshal.ThrowExceptionForHR(_AudioSessionManager.GetSessionEnumerator(out _SessionEnum));
	}
