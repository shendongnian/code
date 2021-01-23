    if (nodes2 != null)
    {
        foreach (HtmlNode nn in nodes2)
        {
            q = nn.InnerText;
            q = System.Net.WebUtility.HtmlDecode(q);
            q = q.Trim();
            english_word.Add(q);
        }
    }
    else
    {
        MessageBox.Show("No english word is found ");
    }
