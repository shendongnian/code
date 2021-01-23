    foreach (XmlNode node in tweets)
    {
        if (tweets[i].InnerText.Length > 0)
        {
             MessageBox.Show(tweets[node].InnerText);
        }
    }
