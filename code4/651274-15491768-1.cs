    System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(htmlString, @"<p>\s*(.+?)\s*</p>");
        ArrayList groupCollection = new ArrayList();
        while (m.Success)
        {
            groupCollection.Add(m.Value);
            m = m.NextMatch();
        }
        ArrayList paragraphs = new ArrayList();
        if (groupCollection.Count > 0)
        {
            foreach (object item in groupCollection)
            {
                try
                {
                    System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("<[^>]*>");
                    // replace all matches with empty string
                    string str = rx.Replace(item.ToString(), "");
                    string str1 = str.Replace("&nbsp;", "");
                    if (!String.IsNullOrEmpty(str1))
                    {
                        paragraphs.Add(item.ToString());
                    }
                }
                catch
                {
                    //This try-catch just prevent future error.
                }
            }
        }
