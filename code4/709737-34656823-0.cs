    static void Main(string[] args)
        {
            Console.WriteLine("We have started");                                    
            string pageName = "http://hrp-dmu.uganda.hrpsolutions.co.ug:9047/DynamicsNAV80/WS/Uganda%20Management%20Institute/Page/CustomerWS";            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(pageName);
            req.Method = "POST";
            req.ContentType = "text/xml;charset=UTF-8";
            req.ProtocolVersion = new Version(1, 1);
            req.Headers.Add("SOAPAction", @"urn:microsoftdynamicsschemas/page/customerws:Create");            
            Console.WriteLine("After preparing request object");
            string xmlRequest = GetTextFromXMLFile("E:\\tst3.xml");
            Console.WriteLine("xml request : "+xmlRequest);
            byte[] reqBytes = new UTF8Encoding().GetBytes(xmlRequest);
            req.ContentLength = reqBytes.Length;
            try
            {
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(reqBytes, 0, reqBytes.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetRequestStreamException : " + ex.Message);
            }
            HttpWebResponse resp = null;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (Exception exc)
            {
                Console.WriteLine("GetResponseException : " + exc.Message);
            }
            string xmlResponse = null;
            if (resp == null)
            {
                Console.WriteLine("Null response");
            }
            else
            {
                using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                {
                    xmlResponse = sr.ReadToEnd();
                }
                Console.WriteLine("The response");
                Console.WriteLine(xmlResponse);
            }
            Console.ReadKey();
        }
        private static string GetTextFromXMLFile(string file)
        {
            StreamReader reader = new StreamReader(file);
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }
