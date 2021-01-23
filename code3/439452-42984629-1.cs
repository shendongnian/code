     string GetSqlStatement(string key)
        {
                string path =   Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase) + @"\DataLayer.dll.config";
            
            XDocument doc = XDocument.Load(path);
            
            var query = doc.Descendants("sqlSection").Nodes().Cast<XElement>().Where(x => x.Attribute("key").Value.ToString() == key).FirstOrDefault();
            if (query != null)
            {
                return query.Attribute("value").Value.ToString();
            }
