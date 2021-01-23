	for (int index = 0; index < DT.Rows.Count; index++)
	{
		foreach (DataColumn DC in DT.Columns)
		{
			DT.Rows[index][DC] = index;
		}
	}
