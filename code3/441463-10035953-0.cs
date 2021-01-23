    foreach (SqlParameter parameter in dbCommand.Parameters)
	{
		if (parameter.SqlDbType != SqlDbType.Structured)
		{
			continue;
		}
		string name = parameter.TypeName;
		int index = name.IndexOf(".");
		if (index == -1)
		{
			continue;
		}
		name = name.Substring(index + 1);
		if (name.Contains("."))
		{
			parameter.TypeName = name;
		}
	}
