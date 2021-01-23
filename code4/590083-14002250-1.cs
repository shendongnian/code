        /// <summary>
        /// Loads this class properties by REST invocation
        /// </summary>
        /// <returns>
        /// true: Successfully loaded 
        /// false: Failed to load 
        ///  </returns>
        public bool LoadMyClass()
        {
            try
            {
                string strSubscriberURL = "http://SERVERIP/url/";
                HttpWebRequest request = WebRequest.Create(strSubscriberURL) as HttpWebRequest;
                request.Credentials = new NetworkCredential(loginUserName, password);
                WebResponse response = request.GetResponse();
                //Load the XML from the Stream
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(response.GetResponseStream());
                //Use the reflection to get all the properties of this class object and set those
                System.Reflection.PropertyInfo[] arrPropInfo = this.GetType().GetProperties();
                for (int i = 0; i < arrPropInfo.Length; i++)
                {
                    string xmlname = arrPropInfo[i].Name;
                    System.Reflection.PropertyInfo propInfo = arrPropInfo[i];
                    XmlNodeList elemList = doc.GetElementsByTagName(xmlname);
                    String xmlValue = "";
                    for (int j = 0; j < elemList.Count; j++)
                    {
                        xmlValue = elemList[j].InnerText;
                    }
                    //TYPE Converstion :Default will be String
                    Object typeCastedValue = xmlValue;
                    if (propInfo.PropertyType.Name.Equals("Boolean"))
                    {
                        typeCastedValue = xmlValue.Equals("true") ? true : false;
                    }
                    else if (propInfo.PropertyType.Name.Equals("Int32"))
                    {
                        typeCastedValue = Convert.ToInt32(xmlValue);
                    }
                    propInfo.SetValue(this, typeCastedValue, null);
                }
			}
            catch (WebException webex)
            {
                var response = webex.Response as HttpWebResponse;
                int errCode = 0;
                if (response != null)
                {
                    errCode = (int)response.StatusCode;
                    Debug.WriteLine("HTTP Status Code: " + (int)response.StatusCode + " "+ response.StatusCode.ToString());
                } 
				return false;
            }
            return true;				
		}
        public static bool sendRequest(string requestURL, HTTPRequestMethod requestMethod,
            NetworkCredential m_netCred, String xml, ErrorResponse m_objErrorResponse)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestURL) as HttpWebRequest;
                request.PreAuthenticate = true;
                request.Credentials = m_netCred;
                request.Method = requestMethod.ToString();
                request.AllowAutoRedirect = false;
                request.ReadWriteTimeout = 100000;
                request.ContentLength = xml.Length;
                request.ContentType = "application/xml; encoding='utf-8'";
                Debug.WriteLine("XML: {0}", xml);
                StreamWriter postStream = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                postStream.Write(xml);
                postStream.Close();
                WebResponse response = request.GetResponse();
                //Get the confschedule ID created
                if (requestMethod == HTTPRequestMethod.POST)
                {
                    HttpWebResponse webResp = response as HttpWebResponse;
                    string temp = response.Headers["Location"];
                    string[] parts = temp.Split('/');
                    id = parts[parts.Length - 1];
                }
                response.Close();
            }
            catch (WebException webex)
            {
                var response = webex.Response as HttpWebResponse;
                int errCode = 0;
                if (response != null)
                {
                    errCode = (int)response.StatusCode;
                    Debug.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    if ((int)response.StatusCode != 500)
                    {
                        m_objErrorResponse.UpdateErrorResponse(errCode.ToString(), response.StatusCode.ToString(), "");
                    }
                    else
                    {
                        m_objErrorResponse.UpdateErrorResponse(errCode.ToString(), response.StatusCode.ToString(),
                            response.Headers.ToString().Split(':')[2]);
                    }
                    Debug.WriteLine(webex.Status.ToString());
                    Debug.WriteLine(webex.Response.ToString());
                    Debug.WriteLine(response.Headers.ToString());
                    WebHeaderCollection col = response.Headers;
                    for (int i = 0; i < col.Count; i++)
                    {
                        Debug.WriteLine(col.Get(i));
                        Debug.WriteLine(response.GetResponseHeader(col.Get(i)));
                    }
                }
                return false;
            }
            return true;
        }
