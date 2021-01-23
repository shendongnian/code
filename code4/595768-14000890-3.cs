    public static XDocument Load(Stream stream, LoadOptions options)
    {
    	XmlReaderSettings xmlReaderSettings = XNode.GetXmlReaderSettings(options);
    	XDocument result;
    	using (XmlReader xmlReader = XmlReader.Create(stream, xmlReaderSettings))
    	{
    		result = XDocument.Load(xmlReader, options);
    	}
    	return result;
    }
    // which calls...
    public static XDocument Load(XmlReader reader, LoadOptions options)
    {
    	if (reader == null)
    	{
    		throw new ArgumentNullException("reader");
    	}
    	if (reader.ReadState == ReadState.Initial)
    	{
    		reader.Read();
    	}
    	XDocument xDocument = new XDocument();
    	if ((options & LoadOptions.SetBaseUri) != LoadOptions.None)
    	{
    		string baseURI = reader.BaseURI;
    		if (baseURI != null && baseURI.Length != 0)
    		{
    			xDocument.SetBaseUri(baseURI);
    		}
    	}
    	if ((options & LoadOptions.SetLineInfo) != LoadOptions.None)
    	{
    		IXmlLineInfo xmlLineInfo = reader as IXmlLineInfo;
    		if (xmlLineInfo != null && xmlLineInfo.HasLineInfo())
    		{
    			xDocument.SetLineInfo(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
    		}
    	}
    	if (reader.NodeType == XmlNodeType.XmlDeclaration)
    	{
    		xDocument.Declaration = new XDeclaration(reader);
    	}
    	xDocument.ReadContentFrom(reader, options);
    	if (!reader.EOF)
    	{
    		throw new InvalidOperationException(Res.GetString("InvalidOperation_ExpectedEndOfFile"));
    	}
    	if (xDocument.Root == null)
    	{
    		throw new InvalidOperationException(Res.GetString("InvalidOperation_MissingRoot"));
    	}
    	return xDocument;
    }
    // which calls...
    internal void ReadContentFrom(XmlReader r, LoadOptions o)
    {
    	if ((o & (LoadOptions.SetBaseUri | LoadOptions.SetLineInfo)) == LoadOptions.None)
    	{
    		this.ReadContentFrom(r);
    		return;
    	}
    	if (r.ReadState != ReadState.Interactive)
    	{
    		throw new InvalidOperationException(Res.GetString("InvalidOperation_ExpectedInteractive"));
    	}
    	XContainer xContainer = this;
    	XNode xNode = null;
    	NamespaceCache namespaceCache = default(NamespaceCache);
    	NamespaceCache namespaceCache2 = default(NamespaceCache);
    	string text = ((o & LoadOptions.SetBaseUri) != LoadOptions.None) ? r.BaseURI : null;
    	IXmlLineInfo xmlLineInfo = ((o & LoadOptions.SetLineInfo) != LoadOptions.None) ? (r as IXmlLineInfo) : null;
    	while (true)
    	{
    		string baseURI = r.BaseURI;
    		switch (r.NodeType)
    		{
    		case XmlNodeType.Element:
    		{
    			XElement xElement = new XElement(namespaceCache.Get(r.NamespaceURI).GetName(r.LocalName));
    			if (text != null && text != baseURI)
    			{
    				xElement.SetBaseUri(baseURI);
    			}
    			if (xmlLineInfo != null && xmlLineInfo.HasLineInfo())
    			{
    				xElement.SetLineInfo(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
    			}
    			if (r.MoveToFirstAttribute())
    			{
    				do
    				{
    					XAttribute xAttribute = new XAttribute(namespaceCache2.Get((r.Prefix.Length == 0) ? string.Empty : r.NamespaceURI).GetName(r.LocalName), r.Value);
    					if (xmlLineInfo != null && xmlLineInfo.HasLineInfo())
    					{
    						xAttribute.SetLineInfo(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
    					}
    					xElement.AppendAttributeSkipNotify(xAttribute);
    				}
    				while (r.MoveToNextAttribute());
    				r.MoveToElement();
    			}
    			xContainer.AddNodeSkipNotify(xElement);
    			if (r.IsEmptyElement)
    			{
    				goto IL_30A;
    			}
    			xContainer = xElement;
    			if (text != null)
    			{
    				text = baseURI;
    				goto IL_30A;
    			}
    			goto IL_30A;
    		}
    		case XmlNodeType.Text:
    		case XmlNodeType.Whitespace:
    		case XmlNodeType.SignificantWhitespace:
    			if ((text != null && text != baseURI) || (xmlLineInfo != null && xmlLineInfo.HasLineInfo()))
    			{
    				xNode = new XText(r.Value);
    				goto IL_30A;
    			}
    			xContainer.AddStringSkipNotify(r.Value);
    			goto IL_30A;
    		case XmlNodeType.CDATA:
    			xNode = new XCData(r.Value);
    			goto IL_30A;
    		case XmlNodeType.EntityReference:
    			if (!r.CanResolveEntity)
    			{
    				goto Block_25;
    			}
    			r.ResolveEntity();
    			goto IL_30A;
    		case XmlNodeType.ProcessingInstruction:
    			xNode = new XProcessingInstruction(r.Name, r.Value);
    			goto IL_30A;
    		case XmlNodeType.Comment:
    			xNode = new XComment(r.Value);
    			goto IL_30A;
    		case XmlNodeType.DocumentType:
    			xNode = new XDocumentType(r.LocalName, r.GetAttribute("PUBLIC"), r.GetAttribute("SYSTEM"), r.Value, r.DtdInfo);
    			goto IL_30A;
    		case XmlNodeType.EndElement:
    		{
    			if (xContainer.content == null)
    			{
    				xContainer.content = string.Empty;
    			}
    			XElement xElement2 = xContainer as XElement;
    			if (xElement2 != null && xmlLineInfo != null && xmlLineInfo.HasLineInfo())
    			{
    				xElement2.SetEndElementLineInfo(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
    			}
    			if (xContainer == this)
    			{
    				return;
    			}
    			if (text != null && xContainer.HasBaseUri)
    			{
    				text = xContainer.parent.BaseUri;
    			}
    			xContainer = xContainer.parent;
    			goto IL_30A;
    		}
    		case XmlNodeType.EndEntity:
    			goto IL_30A;
    		}
    		break;
    		IL_30A:
    		if (xNode != null)
    		{
    			if (text != null && text != baseURI)
    			{
    				xNode.SetBaseUri(baseURI);
    			}
    			if (xmlLineInfo != null && xmlLineInfo.HasLineInfo())
    			{
    				xNode.SetLineInfo(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
    			}
    			xContainer.AddNodeSkipNotify(xNode);
    			xNode = null;
    		}
    		if (!r.Read())
    		{
    			return;
    		}
    	}
    	goto IL_2E1;
    	Block_25:
    	throw new InvalidOperationException(Res.GetString("InvalidOperation_UnresolvedEntityReference"));
    	IL_2E1:
    	throw new InvalidOperationException(Res.GetString("InvalidOperation_UnexpectedNodeType", new object[]
    	{
    		r.NodeType
    	}));
    }
