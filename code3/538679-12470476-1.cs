        String Data = GetURLData(url);
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(Data);
    
    
    
    
        public static string GetURLData(string URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
                request.UserAgent = "Omurcek";
                request.Timeout = 4000;
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }   
            catch (Exception ex )
            {
                LogYaz("Receive DATA Error : " + URL   + ex.ToString());
                return "";
            }
        }
