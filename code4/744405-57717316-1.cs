    '''
    public enum DuplicateHeaderReplacementStrategy
    {
        AppendAlpha,
        AppendNumeric,
        Delete
    }
    
    public class HtmlServices
    {
        private static readonly string[] Alpha = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public static HtmlDocument RenameDuplicateHeaders(HtmlDocument doc, DuplicateHeaderReplacementStrategy strategy)
        {
            var index = 0;
            try
            {
                foreach (HtmlNode table in doc.DocumentNode?.SelectNodes("//table"))
                {
                    var tableHeaders = table.SelectNodes("th")?
                       .GroupBy(x => x)?
                       .Where(g => g.Count() > 1)?
                       .ToList();
                    tableHeaders?.ForEach(y =>
                       {
                           switch (strategy)
                           {
                               case DuplicateHeaderReplacementStrategy.AppendNumeric:
                                   y.Key.InnerHtml += index++;
                                   break;
                               case DuplicateHeaderReplacementStrategy.AppendAlpha:
                                   y.Key.InnerHtml += Alpha[index++];
                                   break;
                               case DuplicateHeaderReplacementStrategy.Delete:
                                   y.Key.InnerHtml = string.Empty;
                                   break;
                           }
                    });
                }
                return doc;
            }
            catch
            {
                return doc;
            }
            
        }
    }
    public static DataTable GetDataTableFromHtmlTable(string url, string[] htmlIds)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            string html = doc.DocumentNode.OuterHtml;
            
            doc = HtmlServices.RenameDuplicateHeaders(doc, DuplicateHeaderReplacementStrategy.AppendNumeric);
            var headers = doc.DocumentNode.SelectNodes("//tr/th");
            DataTable table = new DataTable();
            foreach (HtmlNode header in headers)
                if (!table.ColumnExists(header.InnerText))
                {
                    table.Columns.Add(header.InnerText); // create columns from th
                }
                else
                {
                    int columnIteration = 0;
                    while (table.ColumnExists(header.InnerText + columnIteration.ToString()))
                    {
                        columnIteration++;
                    }
                    table.Columns.Add(header.InnerText + columnIteration.ToString()); // create columns from th
                }
            // select rows with td elements
            foreach (var row in doc.DocumentNode.SelectNodes("//tr[td]"))
            {
                var addRow = row.SelectNodes("td").Select(td => td.InnerHtml.StripHtmlTables()).ToArray();
                if (addRow.Count() > table.Columns.Count)
                {
                    int m_numberOfRowsToAdd = addRow.Count() - table.Columns.Count;
                    for (int i = 0; i < m_numberOfRowsToAdd; i++)
                        table.Columns.Add($"ExtraColumn {i + 1}");
                }
                try
                {
                    table.Rows.Add(addRow);
                }
                catch (Exception e)
                {
                    debug.Print(e.Message);
                }
            }
            return table;
        }
