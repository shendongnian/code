    using System.Linq;
    ...
    var tablecollection = doc.DocumentNode.SelectNodes("//table");
    string store = string.Empty;
    if (tablecollection != null)
    {
        foreach (HtmlNode table in tablecollection)
        {
            foreach (HtmlNode row in table.DescendantNodes().Where(desc => desc.Name.Equals("tr", StringComparison.OrdinalIgnoreCase) && desc.DescendantNodes().Any(child => child.Name.Equals("td", StringComparison.OrdinalIgnoreCase))))
            {
                // using string.join as a less hideous method of removing the trailing pipe
                store = string.Join("|", row.DescendantNodes().Where(
                    desc => desc.Name.Equals("td", StringComparison.OrdinalIgnoreCase)).Select(
                        desc => desc.InnerText));
                sw.Write(store);
                sw.WriteLine();
            }
        }
    }
    sw.Flush();
    sw.Close(); 
