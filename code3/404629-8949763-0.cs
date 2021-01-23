    // parse the token from the json string, 
    var token = JsonNotifyRequestSecurityTokenResponse.FromJson(txtReceivedToken.Text);
    // get the security token and decode it
    string xmlString = HttpUtility.UrlDecode(token.SecurityTokenString);
    // get the base64 string an
    string string64 = "";
    using (XmlReader xmlReader = XmlReader.Create(new StringReader(xmlString))) {
      while (xmlReader.Read()) {
        if (xmlReader.NodeType == XmlNodeType.Text) { // find the first text element, which should be the base64 string
          string64 = xmlReader.Value;
          break;
        }
      }
    }
    // decode it
    string acsToken = base64Decode(string64);
    // set the header
    string headerValue = string.Format("WRAP access_token=\"{0}\"", acsToken);
    client.Headers.Add("Authorization", headerValue);
    Stream stream = client.OpenRead(@"http://127.0.0.1:81/Service1.svc/users");
    StreamReader reader = new StreamReader(stream);
    String response = reader.ReadToEnd();
