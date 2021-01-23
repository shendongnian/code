                StringBuilder sb = new StringBuilder("OAuth ");
                sb.AppendFormat("oauth_version={0},", "1.0");
                sb.AppendFormat("oauth_signature_method={0},", "HMAC-SHA1");
                sb.AppendFormat("oauth_nonce={0},", nonce);
                sb.AppendFormat("oauth_timestamp={0},", timeStamp);
                sb.AppendFormat("oauth_consumer_key={0},", consumerKey);
                sb.AppendFormat("oauth_token={0},", oauth_token);
                sb.AppendFormat("oauth_signature={0}", sig);
                Debug.WriteLine(sb.ToString());
                var request = (HttpWebRequest)WebRequest.Create((resourceUrl));
                request.Headers[HttpRequestHeader.Authorization] = sb.ToString();
                request.ContentType = "text/xml";
                request.Accept = "text/xml";
                request.KeepAlive = true;
                //request.Method = WebRequestMethods.Http.Get;
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Debug.WriteLine(response.StatusCode);
                Debug.WriteLine(response.Server);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader responseReader = new StreamReader(responseStream);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(response.GetResponseStream());
                    Dts.Variables["User::XML_Response"].Value = xmlDoc.OuterXml.ToString();
                }
