    string urlpath = "http://www.example.com/folder/"
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlpath);
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
           using (StreamReader reader = new StreamReader(response.GetResponseStream()))
           {
               string html = reader.ReadToEnd();
               Regex regEx = new Regex(@".*/(?<filename>.*?)\.zip");
               MatchCollection matches = regEx.Matches(html);
               if (matches.Count > 0)
               {
                    foreach (Match match in matches)
                    {
                      if (match.Success)
                      {
                                        
                        Console.WriteLine(match.Groups["filename"].Value);
                      }
                }
           }
    
       }
 
