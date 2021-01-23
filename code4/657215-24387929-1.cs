    List<string> toExclude = new List<string>();
    for (int i = 0; i < dt.Rows.Count; i++)
    {
    	var idValue = (string)dt.Rows[i]["ID"];
    	if (toExclude.Contains(idValue))
    	{
    		dt.Rows.Remove(dt.Rows[i]);
    		i--;
    	}
    	toExclude.Add(glAccount);
    }
