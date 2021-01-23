        using (WebClient wc = new WebClient())
        {            
            string xml = wc.DownloadString(url);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
        }
