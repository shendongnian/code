	public void SetError(Control ctl, string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			mErrors.Remove(ctl);
		}
		else if (!mErrors.Contains(ctl)) 
		{
			mErrors.Add(ctl);
			if (_isFirstError)
			{
                _isFirstError = false;
				ctl.Focus();
			}
		}
		
		mProvider.SetError(ctl, text);
	}
