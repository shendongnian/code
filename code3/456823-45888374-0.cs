        private KeyValuePair<byte[], FileInfo> parse(MessagePart part)
        {
            var _steam = new MemoryStream();
            part.Save(_steam);
            //...
            var _info = new FileInfo(part.FileName);
            return new KeyValuePair<byte[], FileInfo>(_steam.ToArray(), _info);
        }
		
		//... How to use
		var _attachments = message 
			.FindAllAttachments()
			.Select(a => parse(a))
		;
