    abstract class OneColumnParser<TCol> where TCol : new()
    {
        private static MethodInfo ParseInfo = typeof(TCol).GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string) }, null);
        abstract string Column1;
        static OneColumnParser()
        {
            if (ParseInfo == null)
                throw new InvalidOperationException("Invalid type, must contain public static Parse(string)");
        }
        private static TCol Parse(string value)
        {
            return (TCol)ParseInfo.Invoke(null, new[] { value });
        }
        List<TCol> ParseQueryResult(string queryResult)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(queryResult);
            List<TCol> results = new List<TCol>();
            foreach (XmlNode xNode in xDoc.GetElementsByTagName(Column1))
            {
                results.Add(Parse(xNode.InnerText));
            }
            return results;
        }
    }
