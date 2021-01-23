    private static void ReadXmlExt(XmlReader xmlReader, IXmlSerializableExt xmlSerializable, ReadElementDelegate readElementCallback)
	{
		bool isEmpty;
		if (xmlReader == null)
			throw new ArgumentNullException("xmlReader");
		if (readElementCallback == null)
			throw new ArgumentNullException("readElementCallback");
		// Empty element?
		isEmpty = xmlReader.IsEmptyElement;
		// Decode attributes
		if ((xmlReader.HasAttributes == true) && (xmlSerializable != null))
			xmlSerializable.ReadAttributes(xmlReader);
		// Read the root start element
		xmlReader.ReadStartElement();
		// Decode elements
		if (isEmpty == false) {
			do {
				// Read document till next element
				xmlReader.MoveToContent();
				if (xmlReader.NodeType == XmlNodeType.Element) {
					string elementName = xmlReader.LocalName;
					// Empty element?
					isEmpty = xmlReader.IsEmptyElement;
					// Decode child element
					readElementCallback(xmlReader);
					xmlReader.MoveToContent();
					// Read the child end element (not empty)
					if (isEmpty == false) {
						// Delegate check: it has to reach and end element
						if (xmlReader.NodeType != XmlNodeType.EndElement)
							throw new InvalidOperationException(String.Format("not reached the end element"));
						// Delegate check: the end element shall correspond to the start element before delegate
						if (xmlReader.LocalName != elementName)
							throw new InvalidOperationException(String.Format("not reached the relative end element of {0}", elementName));
						// Child end element
						xmlReader.ReadEndElement();
					}
				} else if (xmlReader.NodeType == XmlNodeType.Text) {
					if (xmlSerializable != null) {
						// Interface
						xmlSerializable.ReadText(xmlReader);
						Debug.Assert(xmlReader.NodeType != XmlNodeType.Text, "IXmlSerializableExt.ReadText shall read the text");
					} else
						xmlReader.Skip();	// Skip text
				}
			} while (xmlReader.NodeType != XmlNodeType.EndElement);
		}
	}
