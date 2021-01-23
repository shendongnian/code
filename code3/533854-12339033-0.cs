    interface IParseable
    {
        void Parse(string text);
    }
    abstract class OneColumnParser<T> where T : IParseable, new
    {
        abstract string Column1;
    
        List<T> ParseQueryResult<T>(string queryResult)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(queryResult);
            var results = new List<T>();
    
            foreach (XmlNode xNode in xDoc.GetElementsByTagName(Column1))
            {
                var col = new T();
                col.Parse(xNode.InnerText);
                results.Add(col);
            }
        }
    }
