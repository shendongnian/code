    string number = "102,000,000.80";
    var parts = number.Split(',');
    for (int i = 0; i < parts.Length; i++)
    {
        var len = parts[i].Length;
        if ((len != 3) && (i == parts.Length - 1) && (parts[i].IndexOf('.') != 3))
        {
            Console.WriteLine("error");
        }
        else
        {
            Console.WriteLine(parts[i]);
        }
    }
    // Respecting Culture
	static Boolean CheckThousands(String value)
	{
		String[] parts = value.Split(new string[] { CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator }, StringSplitOptions.None);
		foreach (String part in parts)
		{
			int length = part.Length;
			if (CultureInfo.CurrentCulture.NumberFormat.NumberGroupSizes.Contains(length) == false)
			{
				return false;
			}
		}
		return true;
	}
