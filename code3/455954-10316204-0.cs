    	private void SaveDateTimeCell(XmlNode rowNode, XmlDocument ownerDocument, double number, string format)
		{
			XmlElement cellNode = ownerDocument.CreateElement("table:table-cell", this.GetNamespaceUri("table"));
			XmlAttribute valueType = ownerDocument.CreateAttribute("office:value-type", this.GetNamespaceUri("office"));
			valueType.Value = "date";
			cellNode.Attributes.Append(valueType);
			XmlAttribute value = ownerDocument.CreateAttribute("office:date-value", this.GetNamespaceUri("office"));
			value.Value = Utils.DateTime(number).ToString("yyyy-MM-ddTHH:mm:ss");
			cellNode.Attributes.Append(value);
			XmlAttribute tableStyleName = ownerDocument.CreateAttribute("table:style-name", this.GetNamespaceUri("table"));
			tableStyleName.Value = "ce2";
			cellNode.Attributes.Append(tableStyleName);
			rowNode.AppendChild(cellNode);
		}
