      protected void Page_Load(object sender, EventArgs e)
            {
                BlogFeeds();
            }
            protected void BlogFeeds()
            {
    
                try
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList items = default(XmlNodeList);
                    
                    xmldoc.Load("http://rss.cnn.com/rss/edition_americas.rss");
                    items = xmldoc.SelectNodes("/rss/channel/item");
                    ReadTopArticles(items);
    
                    xmldoc.Load("http://feeds.bbci.co.uk/news/rss.xml?edition=int#");
                    items = xmldoc.SelectNodes("/rss/channel/item");
                    ReadTopArticles(items);
    
                }
                catch (Exception eax)
                {
                    return;
                }
            }
            private void ReadTopArticles(XmlNodeList items)
            {
                string title = string.Empty;
                string link = string.Empty;
                string desc = string.Empty;
                string pubDesc = string.Empty;
                string st = "";
                int i = 0;
    
                foreach (XmlNode item1 in items)
                {
                    foreach (XmlNode node1 in item1.ChildNodes)
                    {
                        if (node1.Name == "title")
                        {
                            title = node1.InnerText;
                        }
                        if (node1.Name == "link")
                        {
                            link = node1.InnerText;
                        }
                        if (node1.Name == "description")
                        {
                            desc = node1.InnerText;
                            if (desc.Length > 90)
                            {
                                pubDesc = desc.Substring(0, 90);
                            }
                            else
                            { pubDesc = desc; }
                        }
                    }
                    st += String.Format("<a target='_blank' href='{0}'>{1}</a><br />{2} ... <div style='border-bottom: 1px dotted #84acfd; padding-top:10px;'></div></br>", link, title, pubDesc);
                    i += 1;
                    if (i == 3)
                        break;
                }
                lblBlogOutput.Text += st;
            }
