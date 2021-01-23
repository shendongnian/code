	[Cloning] // <-- applying the attribute only to desired properties
	public int Test { get; set; }
    public bool Clone(Person other)
	{
		bool changed = false;
		var properties = typeof(Person).GetProperties();
		foreach (var prop in properties.Where(x => x.GetCustomAttributes(typeof(CloningAttribute), true).Length != 0))
		{
			// get current values
			var myValue = prop.GetValue(this, null);
			var otherValue = prop.GetValue(other, null);
			if (prop.PropertyType == typeof(string))
			{
				// special treatment for string:
                // ignore if null !!or empty!!
				if (String.IsNullOrEmpty((string)otherValue))
				{
					continue;
				}
			}
			else
			{
				// do you want to copy if the other value is null?
				if (otherValue == null)
				{
					continue;
				}
			}
			// compare and only check 'changed' if they are different
			if (!myValue.Equals(otherValue))
			{
				changed = true;
				prop.SetValue(this, otherValue, null);
			}
		}
		return changed;
	}
