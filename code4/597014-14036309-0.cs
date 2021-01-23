    //First navigate to your address
     webBrowser1.Navigate("http://en.wikipedia.org/wiki/2012_in_film");
            List<string> Genre = new List<string>();
            List<string> Title = new List<string>();
      //When page loaded
      foreach (HtmlElement table in webBrowser1.Document.GetElementsByTagName("table"))
                {
                    if (table.GetAttribute("className").Equals("wikitable"))
                    {
                        foreach (HtmlElement tr in table.GetElementsByTagName("tr"))
                        {
                            int columncount = 1;
                            foreach (HtmlElement td in tr.GetElementsByTagName("td"))
                            {
                                //Title
                                if (columncount == 4)
                                {
                                    Title.Add(td.InnerText);
                                }
                                //Genre
                                if (columncount == 7)
                                {
                                    Genre.Add(td.InnerText);
                                }
                                columncount++;
                            }
    
                        }
                    }
                }
