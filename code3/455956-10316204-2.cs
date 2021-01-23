    	private void AddDateStyle(XmlDocument ownerDocument)
		{
			XmlElement dateStyle = ownerDocument.CreateElement("number:date-style", this.GetNamespaceUri("number"));
			XmlAttribute styleName = ownerDocument.CreateAttribute("style:name", this.GetNamespaceUri("style"));
			styleName.Value = "N79";
			dateStyle.Attributes.Append(styleName);
			XmlAttribute numberOrder = ownerDocument.CreateAttribute("number:automatic-order", this.GetNamespaceUri("number"));
			numberOrder.Value = "true";
			dateStyle.Attributes.Append(numberOrder);
			ownerDocument.AppendChild(dateStyle);
			XmlElement styleStyle = ownerDocument.CreateElement("style:style", this.GetNamespaceUri("style"));
			XmlAttribute styleStyleName = ownerDocument.CreateAttribute("style:name", this.GetNamespaceUri("style"));
			styleStyleName.Value = "ce1";
			styleStyle.Attributes.Append(styleStyleName);
			XmlAttribute styleFamily = ownerDocument.CreateAttribute("style:family", this.GetNamespaceUri("style"));
			styleFamily.Value = "table-cell";
			styleStyle.Attributes.Append(styleFamily);
			XmlAttribute dataStyleName = ownerDocument.CreateAttribute("style:data-style-name", this.GetNamespaceUri("style"));
			dataStyleName.Value = "N79";
			styleStyle.Attributes.Append(dataStyleName);
			ownerDocument.AppendChild(styleStyle);
		}
