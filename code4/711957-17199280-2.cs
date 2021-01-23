        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_serviceUrl);
        req.KeepAlive = false;
        req.ProtocolVersion = HttpVersion.Version10;
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        using (StreamReader streamReader = new StreamReader(resp.GetResponseStream()))
        {
            CsvConfiguration configuration = new CsvConfiguration()
            {
                Delimiter = ";",
                HasHeaderRecord = true,
                IsHeaderCaseSensitive = false
            };
            configuration.RegisterClassMap<EntityMap>();
            CsvReader csvread = new CsvReader(streamReader, configuration);
            List<Entity> record = csvread.GetRecords<Entity>().ToList();
        }
