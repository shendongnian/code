      private static IEnumerable<dynamic> MakeHttpQuery(string uri)
      {
         var request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
         request.Method = "GET";
         request.Accept = "application/json";
         request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
         try
         {
            var response = request.GetResponse();
            var contentEncoding = response.Headers[HttpResponseHeader.ContentEncoding];
            var responseStream = response.GetResponseStream();
            if (!string.IsNullOrEmpty(contentEncoding) && contentEncoding.Equals("gzip"))
            {
               responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            }
            var json = JsonObject.Parse(responseStream);
            var d = json["d"];
            if (!d.IsArray) return new JsonArray(new[] {d}).Values;
            else return ((JsonArray) d).Values;
         }
         catch (WebException webException)
         {
            log4net.LogManager.GetLogger(typeof(ProfileMediaDataInterface)).Error(webException);
            return new JsonArray(new JsonValue[] {}).Values;
         }
      }
