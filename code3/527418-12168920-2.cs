    using System.Linq;
    // ...
    var tablecollection = doc.DocumentNode.SelectNodes("//table");
    string store = string.Empty;
    if (tablecollection != null)
    {
        foreach (HtmlNode table in tablecollection)
        {
            // For all rows with at least one child with the 'td' tag.
            foreach (HtmlNode row in table.DescendantNodes()
                .Where(desc =>
                    desc.Name.Equals("tr", StringComparison.OrdinalIgnoreCase) &&
                    desc.DescendantNodes().Any(child => child.Name.Equals("td",
                        StringComparison.OrdinalIgnoreCase))))
            {
                // Combine the child 'td' elements into an array, join with the pipe
                // to create the output in 'val|val|val' format.
                store = string.Join("|", row.DescendantNodes().Where(desc =>
                    desc.Name.Equals("td", StringComparison.OrdinalIgnoreCase))
                    .Select(desc => desc.InnerText));
                // You can probably get rid of the 'store' variable as it's
                // no longer necessary to store the value of the table's
                // cells over the iteration.
                sw.Write(store);
                sw.WriteLine();
            }
        }
    }
    sw.Flush();
    sw.Close(); 
