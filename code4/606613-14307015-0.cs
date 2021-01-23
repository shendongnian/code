    class Program {
        private const string HttpMethod = "GET";
        private const string UserAgent =
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/534.7 (KHTML, like Gecko) Chrome/7.0.517.41 Safari/534.7";
        static void Main(string[] args) {
            var request = WebRequest.Create("http://infoseek.co.jp/") as HttpWebRequest;
            if (request == null)
                return;
            request.Method = HttpMethod;
            request.UserAgent = UserAgent;
            var response = request.GetResponse() as HttpWebResponse;
            if (response == null)
                return;
            var encoding = TryGetEncoding(response);
            var stream = response.GetResponseStream();
            var document = new HtmlDocument {
                OptionCheckSyntax = true,
                OptionFixNestedTags = true,
                OptionAutoCloseOnEnd = true,
                OptionReadEncoding = true,
                OptionDefaultStreamEncoding = encoding
            };
            document.Load(stream, encoding);
            var d = document.DocumentNode;
        }
        private static Encoding TryGetEncoding(HttpWebResponse response) {
            var charset = response.CharacterSet;
            if (string.IsNullOrWhiteSpace(charset))
                charset = response.ContentEncoding;
            if (string.IsNullOrWhiteSpace(charset))
                return Encoding.UTF8;
            try {
                return Encoding.GetEncoding(charset);
            } catch {
                return Encoding.UTF8;
            }
        }
    }
