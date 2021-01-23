       HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(string.Format("http://website/page.php?name={0}",name));
                webRequest.BeginGetResponse((callBack)=>{
                HttpWebRequest request = (HttpWebRequest)callBack.AsyncState;
                                        WebResponse webResponse = request.EndGetResponse(callBack);
            using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                        {
                            string response = string.Empty;
                            try
                            {
                                response = sr.ReadToEnd();
                            }
                            catch (Exception ex)
                            {
                                response = ex.Message;
                            }
                            action.Invoke(response);
                        }
    webResponse.Close();
    
                },webRequest)
