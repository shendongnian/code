    Dictionary<string, string> changedFields = new Dictionary<string, string>();
    foreach (string fieldName in formFields.Fields.Keys)
    {
    	if (fieldName.Contains("#"))
    	{
    		if (fieldName.Contains("."))
    		{
    			string[] names = fieldName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
    			if (names.Last().Contains("#"))
    			{
    				changedFields.Add(fieldName, String.Format("{0}.{1}", String.Join(".", names, 0, names.Length - 1), names.Last().Replace("#", "")));
    			}
    		}
    		else
    		{
    			changedFields.Add(fieldName, fieldName.Replace("#", ""));
    		}
    	}
    }
    foreach (string oldName in changedFields.Keys)
    {
    	stamper.AcroFields.RenameField(oldName, changedFields[oldName]);
    }
