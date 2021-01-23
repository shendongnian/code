XmlDocument xDoc = new XmlDocument();
xDoc.Load("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=twitter");
XmlNodeList tweets = xDoc.GetElementsByTagName("text");
for (int i = 0; i < tweets.Count; i++)
{
    if (tweets[i].InnerText.Length > 0)
    {
        MessageBox.Show(tweets[i].InnerText);
    }
}
