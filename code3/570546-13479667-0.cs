        public static string Translate(string input, string fromLanguage, string toLanguage)
        {
            using (WebClient webClient = new WebClient())
            {
                string url = string.Format("http://translate.google.com/translate_a/t?client=j&text={0}&sl={1}&tl={2}", Uri.EscapeUriString(input), fromLanguage, toLanguage);
                string result = webClient.DownloadString(url);
                // I used JavaScriptSerializer but another JSON parser would work
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, object> dic = (Dictionary<string, object>)serializer.DeserializeObject(result);
                Dictionary<string, object> sentences = (Dictionary<string, object>)((object[])dic["sentences"])[0];
                return (string)sentences["trans"];
            }
        }
