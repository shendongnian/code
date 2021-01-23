    response = await client.GetAsync(RequestUrl, HttpCompletionOption.ResponseContentRead);
	if (response.IsSuccessStatusCode)
	{
		_data = await response.Content.ReadAsStringAsync();
		try
		{
			XmlDocument _doc = new XmlDocument();
			_doc.LoadXml(_data);
			return Request.CreateResponse(HttpStatusCode.OK, JObject.Parse(_doc.InnerText));
		}
		catch (Exception jex)
		{
			return Request.CreateResponse(HttpStatusCode.BadRequest, jex.Message);
		}
	}
	else
		return Task.FromResult<HttpResponseMessage>(Request.CreateResponse(HttpStatusCode.NotFound)).Result;
