        static void Main(string[] args)
        {
            SoapFormatter formatter = new SoapFormatter();
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://www.google.com");
            HttpWebResponse resp = (HttpWebResponse)myReq.GetResponse();
            // save this soapRequest as a string and customize it for your mocking up
            MemoryStream target = new MemoryStream();
            using(target)
            {
                formatter.Serialize(target, resp);
            }
            string soapRequest = Encoding.UTF8.GetString(target.GetBuffer());
            // now you can use the string to reconstruct the object from the string without needing anything special (other than substituting your own values into the XML)
            HttpWebResponse myMockedObject = (HttpWebResponse)formatter.Deserialize(
                new MemoryStream(Encoding.UTF8.GetBytes(soapRequest)));
        }
