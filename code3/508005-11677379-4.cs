	var ProtocolVersion = new Version(1, 0);
	var StatusCode = HttpStatusCode.OK;
	var StatusDescription = "OK";
	var Headers = new WebHeaderCollection();
	var Content = "";
	var ResponseBody = "";
	// parse http headers
	var headerIndex = 0;
	while (true)
	{
		var httpHeader = stream.ReadLine();
		// parsing header completes
		if (String.IsNullOrWhiteSpace(httpHeader))
			break;
		if (headerIndex == 0)
		{
			// parse http status header
			var headerElements = Regex.Match(httpHeader, @"HTTP/(\d+(?:\.\d*)?|\.\d+)\s(\d{3})\s(.*)").Groups;
			ProtocolVersion = Version.Parse(headerElements[1].Value);
			StatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), headerElements[2].Value);
			StatusDescription = headerElements[3].Value;
		}
		else
		{
			// parse HTTP headers
			var headerElements = Regex.Match(httpHeader, @"^\$?([\w\d\-]*):\s(.*)$").Groups;
			Headers.Add(headerElements[1].Value, headerElements[2].Value);
		}
		headerIndex++;
	}
	// reading content
	if (Headers[HttpResponseHeader.TransferEncoding] != null && Headers[HttpResponseHeader.TransferEncoding].ToUpperInvariant().EndsWith("CHUNKED"))
	{
		var buffer = new byte[1024];
		var index = 0;
		do
		{
			// read next chunked content size
			var chunkLengthString = stream.ReadLine(returnLineEndBytes: false);
			var chunkLength = Convert.ToInt32(chunkLengthString, 16);
			// resize buffer as we proceed
			if (buffer.Length < chunkLength + index)
				Array.Resize(ref buffer, chunkLength + index);
			// end of HTTP response-body
			if (chunkLength == 0)
				break;
			// read chunked part
			var received = 0;
			while (received < chunkLength)
			{
				received += stream.Read(buffer, index + received, chunkLength - received);
			}
			index += received;
			// discard anything until we reach after the first CR LF
			stream.ReadLine();
		}
		while (true);
		do
		{
			var trailer = stream.ReadLine();
			if (String.IsNullOrWhiteSpace(trailer))
				break;
			// TODO: process trailers
		}
		while (true);
		ResponseBody = Encoding.UTF8.GetString(buffer);
	}
	else if (Headers[HttpResponseHeader.ContentLength] != null)
	{
		var buffer = new byte[int.Parse(Headers[HttpResponseHeader.ContentLength])];
		stream.Read(buffer, 0, buffer.Length);
		ResponseBody = Encoding.UTF8.GetString(buffer);
	}
	else
	{
		var reader = new StreamReader(stream);
		ResponseBody = reader.ReadToEnd();
	}
