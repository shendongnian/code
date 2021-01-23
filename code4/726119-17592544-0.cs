    using HtmlAgilityPack;
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new HtmlDocument();
            doc.Load("log.txt");
            var dt = new DataTable();
            bool hasColumns = false;
            foreach (HtmlNode row in doc
                .DocumentNode
                .SelectNodes("//mainelement"))
            {
                if (!hasColumns)
                {
                    hasColumns = true;
                    foreach (var column in row.ChildNodes
                        .Where(node => node.GetType() == typeof(HtmlNode)))
                    {
                        dt.Columns.Add(column.Name);
                    }
                }
                dt.Rows.Add(row.ChildNodes
                    .Where(node => node.GetType() == typeof(HtmlNode))
                    .Select(node => node.InnerText).ToArray());
            }
        }
    }
