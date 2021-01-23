        RestRequest request = new RestRequest("issues/{id}.xml", Method.PUT);
        request.AddParameter("id", ticket.id, ParameterType.UrlSegment);
        request.XmlSerializer = new RedmineXmlSerializer();
        request.AddBody(ticket);
        RestClient client = new RestClient(_baseUrl);
        client.Authenticator = new HttpBasicAuthenticator(_user, _password);
        IRestResponse response = client.Execute(request);
