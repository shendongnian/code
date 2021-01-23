    HtmlNodeCollection tables = doc.DocumentNode.SelectNodes("//table");
    foreach (HtmlNode table in tables)
    {
        var tmp = table.ParentNode;
        if (tmp.OriginalName.Contains("td"))
            MessageBox.Show("The parent of table #" + i + " has" + tmp.ParentNode.ParentNode.Elements("tr").Count().ToString() + " rows.");
    }
