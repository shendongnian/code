    int i = 1;
    HtmlNodeCollection tables = doc.DocumentNode.SelectNodes("//table");
    foreach (HtmlNode table in tables)
    {
        if (!table.ParentNode.OriginalName.Contains("td")) // If table is not sub-table
            MessageBox.Show("Table #" + i + " have " + table.Elements("tr").Count().ToString() + " rows.");
        i++;
    }
