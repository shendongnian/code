    // System.ServiceModel.Channels.Message
    internal void ToString(XmlDictionaryWriter writer)
    {
    	if (this.IsDisposed)
    	{
    		throw TraceUtility.ThrowHelperError(this.CreateMessageDisposedException(), this);
    	}
    	if (this.Version.Envelope != EnvelopeVersion.None)
    	{
    		this.WriteStartEnvelope(writer);
    		this.WriteStartHeaders(writer);
    		MessageHeaders headers = this.Headers;
    		for (int i = 0; i < headers.Count; i++)
    		{
    			headers.WriteHeader(i, writer);
    		}
    		writer.WriteEndElement();
    		MessageDictionary arg_60_0 = XD.MessageDictionary;
    		this.WriteStartBody(writer);
    	}
    	this.BodyToString(writer);
    	if (this.Version.Envelope != EnvelopeVersion.None)
    	{
    		writer.WriteEndElement();
    		writer.WriteEndElement();
    	}
    }
