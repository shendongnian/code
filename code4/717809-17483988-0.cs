      try
            {
                // get response and write to console
                resp = (HttpWebResponse)req.GetResponse();
                StreamReader responseReader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                string output = responseReader.ReadToEnd();
                resp.Close();
                //XmlDocument xmlResponse = new XmlDocument();
                //xmlResponse.LoadXml(output);
                string[] outputArray1 = Regex.Split(output, @"<FullURL>");
                string urlNowAtFrontOfString = outputArray1[1];
                string[] outputArray2 = Regex.Split(urlNowAtFrontOfString, @"</FullURL>");
                response = outputArray2[0];
                //process response
                //show them how to get the full url and specify that in the AddItem request
            }
