    protected void btnGetURLDetails_Click(object sender, EventArgs e)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(txtURL.Text));
        request.Method = WebRequestMethods.Http.Get;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        String responseString = reader.ReadToEnd();
        response.Close();
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(responseString);
        String title = (from x in doc.DocumentNode.Descendants()
                    where x.Name.ToLower() == "title"
                    select x.InnerText).FirstOrDefault();
        String desc = (from x in doc.DocumentNode.Descendants()
                   where x.Name.ToLower() == "description"
                   select x.InnerText).FirstOrDefault();
        List<String> imgs = (from x in doc.DocumentNode.Descendants()
                         where x.Name.ToLower() == "img"
                         select x.Attributes["src"].Value).ToList<String>();
       lblTitle.Text = title;
       lblDescription.Text = desc;
}
