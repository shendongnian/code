    foreach (var i in tweets)
    {
        if (i!=null)
        {
          string ss = (((System.Xml.XmlElement)(i))).InnerText;
          MessageBox.Show(ss);
         }
    }
