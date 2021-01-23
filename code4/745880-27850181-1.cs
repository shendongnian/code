    public class Word
    {
        public string word { get; set; }
        public string sourceDictionary { get; set; }
        public string partOfSpeech { get; set; }
        public string text { get; set; }
    }
    public class WordList
    {
        public List<Word> wordList { get; set; }
    }
    string url = "http://api.wordnik.com:80/v4/word.json/" + word + "/definitions?limit=200&includeRelated=false&sourceDictionaries=all&useCanonical=false&includeTags=false&api_key=a2a73e7b926c924fad7001ca3111acd55af2ffabf50eb4ae5";
    
    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
    webRequest.Method = WebRequestMethods.Http.Get;
    webRequest.Accept = "application/json";
    webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
    webRequest.Referer = "http://developer.wordnik.com/docs.html";
    webRequest.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
    webRequest.Headers.Add("Accept-Language", "en-US,en;q=0.8");
    webRequest.Host = "api.wordnik.com";
    
    HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
    
    string enc = webResponse.ContentEncoding;
    using (Stream stream = webResponse.GetResponseStream())
    {
        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        String responseString = "{\"wordList\":" + reader.ReadToEnd() + "}";
    
        if (responseString != null)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            WordList words = ser.Deserialize<WordList>(responseString);    
        }
    }
