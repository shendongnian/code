    request.GetRequestStreamAsync()
           .ContinueWith((trs) =>
               {
                   var postData = System.Text.Encoding.ASCII.GetBytes("dummy");
                   trs.Result.Write(postData, 0, postData.Length);
                   return request.GetResponseAsync();
               }).Unwrap()
           .ContinueWith((resp) =>
               {
                   using (var sr = new StreamReader(resp.Result.GetResponseStream()))
                   {
                       var str = sr.ReadToEnd();
                   }
               });
