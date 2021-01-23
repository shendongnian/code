    /*-------------------------example of use-------------*/
    MakeXmlRequest<XmlDocument>("your_uri",result=>your_xmlDocument_variable =     result,error=>your_exception_Var = error);
    MakeJsonRequest<classwhateveryouwant>("your_uri",result=>your_classwhateveryouwant_variable=result,error=>your_exception_Var=error)
    /*-------------------------------------------------------------------------------*/
    public class RestService
    {
        public void MakeXmlRequest<T>(string uri, Action<XmlDocument> successAction, Action<Exception> errorAction)
        {
            XmlDocument XMLResponse = new XmlDocument();
            string wufooAPIKey = ""; /*or username as well*/
            string password = "";
            StringBuilder url = new StringBuilder();
            url.Append(uri);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.ToString());
            string authInfo = wufooAPIKey + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Timeout = 30000;
            request.KeepAlive = false;
            request.Headers["Authorization"] = "Basic " + authInfo;
            string documento = "";
            MakeRequest(request,response=> documento = response,
                                (error) =>
                                {
                                 if (errorAction != null)
                                 {
                                    errorAction(error);
                                 }
                                }
                       );
            XMLResponse.LoadXml(documento);
            successAction(XMLResponse);
        }
 
        public void MakeJsonRequest<T>(string uri, Action<T> successAction, Action<Exception> errorAction)
        {
            string wufooAPIKey = "";
            string password = "";
            StringBuilder url = new StringBuilder();
            url.Append(uri);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.ToString());
            string authInfo = wufooAPIKey + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Timeout = 30000;
            request.KeepAlive = false;
            request.Headers["Authorization"] = "Basic " + authInfo;
           // request.Accept = "application/json";
          //  request.Method = "GET";
            MakeRequest(
               request,
               (response) =>
               {
                   if (successAction != null)
                   {
                       T toReturn;
                       try
                       {
                           toReturn = Deserialize<T>(response);
                       }
                       catch (Exception ex)
                       {
                           errorAction(ex);
                           return;
                       }
                       successAction(toReturn);
                   }
               },
               (error) =>
               {
                   if (errorAction != null)
                   {
                       errorAction(error);
                   }
               }
            );
        }
        private void MakeRequest(HttpWebRequest request, Action<string> successAction, Action<Exception> errorAction)
        {
            try{
                using (var webResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        var objText = reader.ReadToEnd();
                        successAction(objText);
                    }
                }
            }catch(HttpException ex){
                errorAction(ex);
            }
        }
        private T Deserialize<T>(string responseBody)
        {
            try
            {
                var toReturns = JsonConvert.DeserializeObject<T>(responseBody);
                 return toReturns;
            }
            catch (Exception ex)
            {
                string errores;
                errores = ex.Message;
            }
            var toReturn = JsonConvert.DeserializeObject<T>(responseBody);
            return toReturn;
        }
    }
    }
