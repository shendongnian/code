	void SetChangeIfNeeded<T>(ref T field, T value, string propertyName)
	{
		if (!EqualityComparer<T>.Default.Equals(field, value))
		{
			field = value;
			SetChanged(property);
		}
	}
