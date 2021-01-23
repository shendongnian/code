	private void LoadData(XmlDocument xmlDoc, Dictionary<string, string> propertyNameToXPathMap)
	{
 		foreach ( PropertyInfo pi in this.GetType().GetProperties() )
		{
			// Is the property mapped to an xpath?
			if ( propertyNameToXPathMap.ContainsKey(pi.Name) )
			{
				string sPathExpression = propertyNameToXPathMap[pi.Name];
				// Extract the Property's value from XML based on the xpath expr.
				string value = xmlDoc.SelectSingleNode(sPathExpression).Value;
				// Set this object's property's value
				pi.SetValue(this, value, null);
			}
		}
	}
