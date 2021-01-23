    StringBuilder codew = new StringBuilder();
    foreach (HtmlAgilityPack.HtmlTextNode node in
          doc.DocumentNode.SelectNodes("//code/text()"))
    {
        codew.Append(node.Text.Trim());
    }
    string foundcode = sb.ToString();
