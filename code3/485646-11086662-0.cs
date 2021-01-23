	public event PropertyChangedEventHandler PropertyChanged;
	 
	private void SetProperty<T>(ref T field, T value, string name)
	{
		if (!EqualityComparer<T>.Default.Equals(field, value))
		{
			field = value;
			var handler = PropertyChanged;
			if (handler != null)
			{
			  handler(this, new PropertyChangedEventArgs(name));
			}
		}
	}
