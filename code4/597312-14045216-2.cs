      class MyWebClient : WebClient
      {
         public string FileName { get; private set; }
         protected override WebResponse GetWebResponse(WebRequest request)
         {
            WebResponse response = base.GetWebResponse(request);
            FileName = Regex.Match(((HttpWebResponse)response).Headers["Content-Disposition"], "filename=(.+?)$").Result("$1");
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            FileName = r.Replace(FileName, "-");
            return response;
         }
      }
