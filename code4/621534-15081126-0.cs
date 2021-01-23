      private void httpPostData()
            {
                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                var uri = new Uri("http://www.sample.com/api/purchases", UriKind.Absolute);
                webClient.Headers[HttpRequestHeader.ContentLength] = postData.Length.ToString();
                webClient.AllowWriteStreamBuffering = true;
                webClient.Encoding = System.Text.Encoding.UTF8;
                webClient.UploadStringAsync(uri, "POST", postData.ToString());
                webClient.UploadStringCompleted += new UploadStringCompletedEventHandler(postComplete);
                System.Threading.Thread.Sleep(200);
            }
  
      private void postComplete(object sender, UploadStringCompletedEventArgs e)
        {
            reset.Set();
            Response result = JsonConvert.DeserializeObject<Response>(e.Result);
            if (result.success == true)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.OK, package_id));
            }
        }
