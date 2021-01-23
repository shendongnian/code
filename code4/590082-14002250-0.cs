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
