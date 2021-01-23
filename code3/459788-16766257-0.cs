    private string GetAlbumRSS(SyndicationItem album)
        {
            string url = "";
            foreach (SyndicationElementExtension ext in album.ElementExtensions)
                if (ext.OuterName == "itemRSS") url = ext.GetObject<string>();
            return (url);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string albumRSS;
            string url = "http://www.SomeSite.com/rss‎";
            XmlReader r = XmlReader.Create(url);
            SyndicationFeed albums = SyndicationFeed.Load(r);
            r.Close();
            foreach (SyndicationItem album in albums.Items)
            {
                cell.InnerHtml = cell.InnerHtml +string.Format("<br \'><a href='{0}'>{1}</a>", album.Links[0].Uri, album.Title.Text);
                albumRSS = GetAlbumRSS(album);
               
            }
           
       
        }
