    void ObjectListResponseReady(IAsyncResult asyncResult)
        {
            try
            {
                HttpWebRequest request = asyncResult.AsyncState as HttpWebRequest;
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);
               
                Deployment.Current.Dispatcher.BeginInvoke(delegate()
                {
					Stream responseStream = response.GetResponseStream();
                    XmlReader xmlReader = XmlReader.Create(responseStream);
				});
				}
				
            catch (Exception ex)
            {
                Message.ErrorMessage("error: " + ex);
            }
			}
