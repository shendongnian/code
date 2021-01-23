     public partial class Sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "http://news.yahoo.com/rss/";
            var el = XElement.Load(url).Elements("channel");
            StringBuilder output = new StringBuilder();
            foreach (var c in el.Elements())
            {
                switch (c.Name.LocalName.ToLower())
                {
                    case "title": 
                        output.Append(c.Value);
                        output.Append("<br />");
                        break;
                }
            }
            this.Label1.Text = output.ToString();
        }
    }
