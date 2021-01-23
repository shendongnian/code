    abstract class OneColumnParser<TCol>
    {
        private static MethodInfo ParseInfo = typeof(TCol).GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string) }, null);
        abstract string Column1;
        static OneColumnParser()
        {
            if (typeof(TCol) != typeof(string) && (ParseInfo == null || !typeof(TCol).IsAssignableFrom(ParseInfo.ReturnType)))
                throw new InvalidOperationException("Invalid type, must contain public static TCol Parse(string)");
        }
        private static TCol Parse(string value)
        {
            if (typeof(TCol) == typeof(string))
                return (TCol)(object)value;
            else
                return (TCol)ParseInfo.Invoke(null, new[] { value });
        }
        public List<TCol> ParseQueryResult(string queryResult)
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
