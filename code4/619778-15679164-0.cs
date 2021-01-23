    private void executesend()
        {  
        
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = "POST";
                    string Data = "message="+keys;
                    byte[] postBytes = Encoding.ASCII.GetBytes(Data);
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = postBytes.Length;
                    Stream requestStream = req.GetRequestStream();
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();
                    HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                    Stream resStream = response.GetResponseStream();
                    var sr = new StreamReader(response.GetResponseStream());
                    string responseText = sr.ReadToEnd();
                    
                }
                catch (WebException)
                {
                    MessageBox.Show("Please Check Your Internet Connection");
                }
