       HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(string.Format("http://website/page.php?name={0}",name));
                webRequest.BeginGetResponse((callBack)=>{
                HttpWebRequest request = (HttpWebRequest)callBack.AsyncState;
                                        WebResponse webResponse = request.EndGetResponse(callBack);
            using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                        {
                            try
                            {
                                string textResponse = sr.ReadToEnd();
                            }
                            catch (Exception)
                            {
                                return string.Empty;
                            }
                        }
    webResponse.Close();
    
                },webRequest)
