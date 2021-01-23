	XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
	XmlElement queryOptions = xmlDoc.CreateElement("QueryOptions");
	if (!includeAllColumns)
	{
		ndViewFields.InnerXml =
			string.Join(string.Empty,
				columnNamesToInclude
				.Select(t1 => string.Format("<FieldRef Name=\"{0}\" />", t1))
				.ToArray());
		queryOptions.InnerXml = "<IncludeMandatoryColumns>FALSE</IncludeMandatoryColumns>";
	}
