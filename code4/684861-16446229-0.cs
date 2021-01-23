      var client = (HttpWebRequest)WebRequest.Create(connectionUrl);
      client.AllowAutoRedirect = false;
      client.Method = "GET";
      client.BeginGetResponse(Callback, client);
      private void Callback(IAsyncResult ar) {
          var state = (HttpWebRequest)ar.AsyncState;
          using (var response = state.EndGetResponse(ar)) {
              var streamResponse = response.GetResponseStream();
              var streamRead = new StreamReader(streamResponse);
              var responseString = streamRead.ReadToEnd();
          }
      }
