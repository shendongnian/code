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
