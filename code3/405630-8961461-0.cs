            string xmlResult = null;
            string botId = "c49b63239e34d1"; // enter your botid
            string talk = "Am I a human?"; 
            string custId = null; // (or a value )
            using (var wc = new WebClient())
            {
                var col = new NameValueCollection();
                col.Add("botid", botId);
                col.Add("input", talk);
                if (!String.IsNullOrEmpty(custId))
                {
                    col.Add("custid", "an id");
                }
                byte[] xmlResultBytes = wc.UploadValues(
                    @"http://www.pandorabots.com/pandora/talk-xml", 
                    "POST", 
                    col);
                xmlResult = UTF8Encoding.UTF8.GetString(xmlResultBytes);
            }
            //raw result
            Console.WriteLine(xmlResult);
            // parse xmlResut
            var xd = new XmlDocument();
            xd.LoadXml(xmlResult);
            var messageNode = xd.GetElementsByTagName("message");           
            if (messageNode.Count>0)
            {
                Console.WriteLine(messageNode[0].InnerText); 
            }
            
