        Byte[] bytes = new Byte[InputFile.PostedFile.InputStream.Length];
        InputFile.PostedFile.InputStream.Read(bytes, 0, bytes.Length);
        string soapStr =
            @"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <CopyIntoItems xmlns=""http://schemas.microsoft.com/sharepoint/soap/"">
                      <SourceUrl>http://devint/a/ceo/PublishingImages/FridayMemoHeader1.png</SourceUrl>
                      <DestinationUrls>
                        <string>http://sp-pubdev:88/Resources/Images/testFile.png</string>
                      </DestinationUrls>
                      <Fields>
                      </Fields>
                      <Stream>{1}</Stream>
                    </CopyIntoItems>
                  </soap:Body>
                </soap:Envelope>";
        System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(Url);
        req.Headers.Add("SOAPAction", "\"http://schemas.microsoft.com/sharepoint/soap/CopyIntoItems\"");
        req.ContentType = "text/xml;charset=\"utf-8\"";
        req.Accept = "text/xml";
        req.Method = "POST";
        //req.Credentials = System.Net.CredentialCache.DefaultCredentials;
        req.Credentials = new System.Net.NetworkCredential("myUserName", "myPassword", "Domain");
        
        using (System.IO.Stream stm = req.GetRequestStream())
        {
            soapStr = string.Format(soapStr, "testFile.png", Convert.ToBase64String(bytes));
            using (System.IO.StreamWriter stmw = new System.IO.StreamWriter(stm))
            {
                stmw.Write(soapStr);
            }
        }
