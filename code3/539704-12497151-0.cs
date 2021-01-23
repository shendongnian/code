    var valueNames = new Dictionary<string, string>();
    foreach (var property in row.GetType().GetProperties())
    {
        if (property.PropertyType.Namespace.Contains("ATG.Agilent.Entities"))
        {
    		var propValue = property.GetValue(row, null);
            foreach (var subProperty in property.PropertyType.GetProperties())
            {
    			if(subProperty.GetValue(propValue, null) != null)
    				valueNames.Add(subProperty.Name, subProperty.GetValue(propValue, null).ToString());
            } 
        }
        else
        {
            var value = property.GetValue(row, null);
            valueNames.Add(property.Name, value == null ? "" : value.ToString());
        }
    }
