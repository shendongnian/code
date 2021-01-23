    public void Upload()
            {
                WebRequest request = HttpWebRequest.Create("http://localhost:7267/Search/uploadFile");
                request.Method = "POST";
                //This is important, MVC uses the content-type to discover the action parameters
                request.ContentType = "application/x-www-form-urlencoded";
    
                byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\myFile.jpg");
    
                StringBuilder serializedBytes = new StringBuilder();
                
                //Let's serialize the bytes of your file
                fileBytes.ToList<byte>().ForEach(x => serializedBytes.AppendFormat("{0}.", Convert.ToUInt32(x)));
    
                string postParameters = String.Concat("fileName={0}&fileBytes=", "myFile.jpg", serializedBytes.ToString());
    
                byte[] postData = Encoding.UTF8.GetBytes(postParameters);
                
                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(postData, 0, postData.Length);
                    postStream.Close();
                }
    
                request.BeginGetResponse(new AsyncCallback(Upload_Completed), request);
            }
    
            private void Upload_Completed(IAsyncResult result)
            {
                WebRequest request = (WebRequest)(result.AsyncState);
                WebResponse response = request.EndGetResponse(result);
                // Parse response
            }
