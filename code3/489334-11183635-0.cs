            var s = RssReader.Read("http://ph.news.yahoo.com/rss/philippines");
            StringBuilder sb = new StringBuilder();
            foreach (RssNews rs in s)
            {
                sb.AppendLine(rs.Title);
                sb.AppendLine(rs.PublicationDate);
                sb.AppendLine(rs.Description);
            }
            textBox1.Text = sb.ToString();
