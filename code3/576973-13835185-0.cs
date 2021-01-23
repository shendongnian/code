    public void crawlURL(string URL)
            {
          
                PageContent = getURLContent(URL);
                MatchCollection matches = Regex.Matches(PageContent, "(href=\"https?://[a-z0-9-._~:/?#\\[\\]@!$&'()*+,;=]+(?=\"|$))", RegexOptions.IgnoreCase);
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
                int count = matches.Count;
           
            }
            private string getURLContent(string URL)
            {
                string content;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
                request.UserAgent = "Fetching contents Data";
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                content = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                return content;
            }
