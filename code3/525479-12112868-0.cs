	int index = Convert.ToInt16(e.CommandArgument);
	
	try
	{
		string str = GridView2.DataKeys[index].Value.ToString();
		Session["studyuid2"] = str;
	}
	catch (ArgumentOutOfRangeException ex) 
	{
		throw new ArgumentOutOfRangeException(
			String.Format(
				"The index passed is not valid for the collection.  The index is '{0}' and must be between 0 and '{1}'.",
				index,
				GridView2.DataKeys.Count));
	}
		
