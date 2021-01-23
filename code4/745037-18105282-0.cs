    class Program
    {
        static void Main()
        {
            var input = File.ReadAllLines("input.txt");
            input.ToList().ForEach(item => {
                Console.WriteLine(item.GetParameter("Aggregate"));
            });
        }
    }
    static class X
    {
        public static string GetParameter(this string expression, string element)
        {
            XDocument doc;
            var input1 = "<root>" + expression
                .Replace("(", "<n1>")
                .Replace(")", "</n1>")
                .Replace("[", "<n2>")
                .Replace("]", "</n2>") +
                "</root>";
            try
            {
                doc = XDocument.Parse(input1);
            }
            catch
            {
                return null;
            }
            var agg=doc.Descendants()
                .Where(d => d.FirstNode.ToString() == element)
                .FirstOrDefault();
            if (agg == null)
                return null;
            var param = agg
                .Elements()
                .FirstOrDefault();
            if (param == null)
                return null;
            return element +
                param
                .ToString()
                .Replace("<n1>", "(")
                .Replace("</n1>", ")")
                .Replace("<n2>", "[")
                .Replace("</n2>", "]");
        }
    }
