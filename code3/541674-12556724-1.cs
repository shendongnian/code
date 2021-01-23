	public static HtmlString DescriptionFor(this Enum theEnum)
	{
		var theEnumType = theEnum.GetType();
			
		//the enum must inherit from Enum, but not actually *be* Enum.
		if (!(theEnum is Enum) || theEnumType.Equals(typeof(Enum))) throw new ArgumentException("Not a valid Enumeration.");
		var fi = theEnumType.GetField(theEnum.ToString());
		var displayAttribute = ((DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false))
			.FirstOrDefault();
		if (displayAttribute == null) return new HtmlString(theEnum.ToString());
		return new HtmlString(displayAttribute.Description ?? theEnum.ToString());
	}
