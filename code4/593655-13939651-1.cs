         try
         {
            WebClient wc = new WebClient();
            wc.Headers.Add();//ADD ALL YOUR HEADERS IF YOU NEED
            var xml = wc.DownloadString(string.Format("http://smart-ip.net/geoip-xml/{0}", txtIP.Text));
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var name = doc.DocumentElement.SelectSingleNode("//countryName");
            txtIPresults.Text = name
         }
         catch (Exception myException)
         {
            throw new Exception("Error Occurred:", myException);
         }
