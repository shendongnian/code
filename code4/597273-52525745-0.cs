     var handler = new HttpClientHandler
            {
                UseDefaultCredentials = true,
                AllowAutoRedirect = true,
                CookieContainer = new System.Net.CookieContainer(),
                UseCookies = true
            };
            var client = new HttpClient(handler) {MaxResponseContentBufferSize = 256000};
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
            client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            client.DefaultRequestHeaders.ExpectContinue = false;
            var samlResponseString = client
                .GetStringAsync(
                    new Uri("https://AdfsServer/adfs/ls/IdpInitiatedSignOn.aspx?logintoRP=RPIdentifier")).Result;
            var parsedSamlResponse = "";
            Regex reg = new Regex("SAMLResponse\\W+value\\=\\\"([^\\\"]+)\\\"");
            MatchCollection matches = reg.Matches(samlResponseString);
            foreach (Match m in matches)
            {
                parsedSamlResponse =  m.Groups[1].Value;
            }        
            string strXMLServer = "https://mysite.webex.com/WBXService/XMLService";
            WebRequest request = WebRequest.Create(strXMLServer);
    // Set the Method property of the request to POST.
            request.Method = "POST";
    // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
    // Create POST data and convert it to a byte array.
            Func<StringBuilder, StringBuilder> webExXML =
                bodySB => new StringBuilder(1024) // Currently 294 bytes in length
                    .AppendLine("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>")
                    .Append("<serv:message xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"")
                    .Append(" xmlns:serv=\"http://www.webex.com/schemas/2002/06/service\"")
                    .Append(" xsi:schemaLocation=\"http://www.webex.com/schemas/2002/06/service")
                    .Append(" http://www.webex.com/schemas/2002/06/service/service.xsd\">")
                    .AppendLine("<header>")
                    .AppendLine("<securityContext>")
                    .AppendLine("<siteName>siteName</siteName>")
                    .AppendLine("<webExID>adminUsername</webExID>")                    
                    .AppendLine("</securityContext>")
                    .AppendLine("</header>")
                    .AppendLine()
                    .AppendLine("<body>")
                    .Append(bodySB)
                    .AppendLine()
                    .AppendLine("</body>")
                    .AppendLine("</serv:message>");
            var xmlAuthBodyContent = new StringBuilder()
                .AppendLine("<bodyContent ")
                .AppendLine("xsi:type=\"java:com.webex.service.binding.user.AuthenticateUser\">")
                .AppendLine($"<samlResponse>{parsedSamlResponse}</samlResponse>")
                .AppendLine("<protocol>SAML2.0</protocol>")
                .AppendLine("</bodyContent>");
            byte[] byteArray = Encoding.UTF8.GetBytes(webExXML(xmlAuthBodyContent).ToString());
    // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
    // Get the request stream.
            Stream dataStream = request.GetRequestStream();
    // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
    // Close the Stream object.
            dataStream.Close();
    // Get the response.
            WebResponse response = request.GetResponse();
            DataSet DSResponse = new DataSet();
            DSResponse.ReadXml(response.GetResponseStream());
            string xmlResponse = DSResponse.GetXml();
