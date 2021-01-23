    public void timeZoneUpdate()
            {
                try
                {
                    arrayToParse.Clear();
                    
                    string URL = @"https://www.google.com/search?q=time+" + rowCity + "%2C+" + rowState;
    
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
                    myRequest.Method = "GET";
                    WebResponse myResponse = myRequest.GetResponse();
                    StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                    string result = sr.ReadToEnd();
                    sr.Close();
                    myResponse.Close();
                    //Console.Write(result);
    
                    HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
                    htmlSnippet.Load(new StringReader(result));
    
                    bool foundSection = false;
    
                    foreach (HtmlAgilityPack.HtmlNode table in htmlSnippet.DocumentNode.SelectNodes("//table"))
                    {
                        foreach (HtmlAgilityPack.HtmlNode row in table.SelectNodes("tr"))
                        {
                            foreach (HtmlAgilityPack.HtmlNode cell in row.SelectNodes("td"))
                            {
                                if (cell.InnerText.Contains("Time"))
                                {
                                    foundSection = true;
                                }
                                if (foundSection)
                                {
                                    //Console.WriteLine("Cell value : " + cell.InnerText);
                                    arrayToParse.Add(cell.InnerText);
                                }
                            }
                        }
                    }
                retrievedTimeZone = arrayToParse[0].ToString().Split('-')[0].Trim();
                if(retrievedTimeZone.Contains("Showing"))
                {
                    retrievedTimeZone = "Undetermined";
                }
            }
