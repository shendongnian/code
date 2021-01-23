	public virtual void SetText(string textData, TextDataFormat format)
	{
		if (!string.IsNullOrEmpty(textData))
		{
			//
		}
		else
		{
			throw new ArgumentNullException("textData");
		}
	}
