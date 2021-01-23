    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
    TwitterUser user = new TwitterUser();
    string url = "http://api.twitter.com/1/account/verify_credentials.xml";
    string xml = oAuth.oAuthWebRequest(oAuthTwitter.Method.GET, url, String.Empty);
                        
    xmlDoc.LoadXml(xml);
    user.id = xmlDoc.SelectSingleNode("user/id").InnerText;
    user.screen_name = xmlDoc.SelectSingleNode("user/screen_name").InnerText;
    user.name = xmlDoc.SelectSingleNode("user/name").InnerText;
