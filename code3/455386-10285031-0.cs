			string requestXml = "someinputxml";
			byte[] bytes = Encoding.UTF8.GetBytes(requestXml);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "application/xml";
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {                   
                    responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
				}
			}
