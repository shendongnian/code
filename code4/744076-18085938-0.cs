    private void sendNotification(String registrationID,String message,String title,String accessToken)
        {
           HttpWebRequest httpWReq =
                (HttpWebRequest)WebRequest.Create("https://api.amazon.com/messaging/registrations/" + registrationID + "/messages");
            Encoding encoding = new UTF8Encoding();
            string postData = "{\"data\":{\"message\":\""+message+"\",\"title\":\""+title+"\"},\"consolidationKey\":\"Some Key\",\"expiresAfter\":86400}";
            byte[] data = encoding.GetBytes(postData);
            httpWReq.ProtocolVersion = HttpVersion.Version11;
            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/json";//charset=UTF-8";
            httpWReq.Headers.Add("X-Amzn-Type-Version",
                                               "com.amazon.device.messaging.ADMMessage@1.0");
            httpWReq.Headers.Add("X-Amzn-Accept-Type",
                                            "com.amazon.device.messaging.ADMSendResult@1.0");
            httpWReq.Headers.Add(HttpRequestHeader.Authorization,
                "Bearer " + accessToken);
            httpWReq.ContentLength = data.Length;
            Stream stream = httpWReq.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
            string s=response.ToString();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            String jsonresponse = "";
            String temp = null;
            while ((temp = reader.ReadLine()) != null)
            {
                jsonresponse += temp;
            }
        }
