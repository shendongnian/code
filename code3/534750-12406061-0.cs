            HtmlDocument doc = new HtmlDocument();
            doc.Load(yourFile);
            // get all TR with a specific class name, starting from root (/), and recursively (//)
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//tr[@class='tblDataGreyNH' or @class='tblDataWhiteNH']"))
            {
                // get all TD below the current node with a specific class name
                HtmlNode inOrOut = node.SelectSingleNode("td[@class='tblHeader']");
                if (inOrOut != null)
                {
                    string io = inOrOut.InnerText.Trim();
                    Console.WriteLine(io.ToUpper());
                    if (io.Contains("Time"))
                    {
                        // normalize-space gets rid or whitespaces (\r,\n, etc.)
                        // text() gets the node's inner text
                        foreach (HtmlNode td in node.SelectNodes("td[normalize-space(@class)='' and normalize-space(text())!='' and normalize-space(text())!='00:00']"))
                        {
                            Console.WriteLine("value:" + td.InnerText.Trim());
                        }
                    }
                }
                // gets all TD below the current node that define the NOWRAP attribute
                HtmlNodeCollection tdNoWraps = node.SelectNodes("td[@nowrap]"); 
                if (tdNoWraps != null)
                {
                    foreach (HtmlNode tdNoWrap in tdNoWraps)
                    {
                        string value = tdNoWrap.InnerText.Trim();
                        if (value == string.Empty)
                            continue;
                        Console.WriteLine("value:" + value);
                    }
                }
            }
