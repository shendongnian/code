            catch (Exception e)
            {
                if (e is WebException)
                {
                    WebException webEx = (WebException)e.InnerException;
                    HttpWebResponse myResponse = webEx.Response as HttpWebResponse;
                    string response = string.Empty;
                    if (myResponse != null)
                    {
                        StreamReader strm = new  StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                        response = strm.ReadToEnd();
                        //EMPTY RESPONSE
                    }
                }
            }
