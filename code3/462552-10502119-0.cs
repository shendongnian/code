        public async Task<List<WordDefinition>> GetDefinitions(string word)
        {
            try
            {
                HttpClient httpclient = new HttpClient();
                var dictService = await httpclient.GetStringAsync("http://services.aonaware.com/DictService/DictService.asmx/DefineInDict?DictId=wn&word=" + word);
                XNamespace ns = "http://services.aonaware.com/webservices/";
                var dictInfo = XElement.Parse(dictService);
                var definitions = dictInfo.Descendants(ns + "Definitions");
                List<WordDefinition> defInfo = (from definition in definitions.Descendants(ns + "Definition")
                                                select new WordDefinition
                                                {
                                                    Word = definition.Element(ns + "Word").Value,
                                                    Definition = definition.Element(ns + "WordDefinition").Value
                                                }).ToList<WordDefinition>();
                return defInfo;
            }
            catch (Exception ex)
            {
                return new List<WordDefinition>();
            }
        }
        public class WordDefinition
        {
            public string Word { get; set; }
            public string Definition { get; set; }
        }
