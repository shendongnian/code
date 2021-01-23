    void ObjectListRequestReady(IAsyncResult asyncResult)
    {
           
         HttpWebRequest request = asyncResult.AsyncState as HttpWebRequest;
         Stream stream = request.EndGetRequestStream(asyncResult);
            
         Deployment.Current.Dispatcher.BeginInvoke(delegate()
         {
                SELECTED_NODE = SPSITETextBox.Text;
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine("pass your data to upload on server");
                writer.Flush();
                writer.Close();
                request.BeginGetResponse(new AsyncCallback(ObjectListResponseReady), request);
				
				// ObjectListResponseReady is the callback method called after uploading the data.
          });
    }
