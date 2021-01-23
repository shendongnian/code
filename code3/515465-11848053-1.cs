    foreach (var i in tweets)
    {
        if (i!=null)
        {
          string tweet= (((System.Xml.XmlElement)(i))).InnerText;
          MessageBox.Show(tweet);
         }
    }
