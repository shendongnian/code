	private Boolean _canSave = false;
	private Boolean CanSave 
	{
		get { return _canSave; }
		set
		{
			_canSave = value;
			MenuSave.Enabled = value;
		}
	}
	public void MenuSave_Click()
	{
		if (CanSave)
		{
		   Save();
		}
	}
	private void Save()
	{
		// do your thing
		
		CanSave = false;
	}
	public void TextBox_TextChanged()
	{
		CanSave = true;
	}
