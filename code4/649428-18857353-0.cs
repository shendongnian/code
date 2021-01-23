    public object Get(string id)
        {
            List<ResultObject> resultValues = new List<ResultObject>();
            foreach (string val in ***SQLQUERYRESULTS***)
            {
                test singleResult = new ResultObject();
                singleResult.Name = val;
                singleResult.Description = "Server";
                singleResult.Url = "***CUSTOMURL***?ServerName=" + val;
                resultValues.Add(singleResult);
            }
            var entities = resultValues;
            var names = entities.Select(m => m.Name);
            var description = entities.Select(m => m.Description);
            var urls = entities.Select(m => m.Url);
            var entitiesJson = new object[] { id, names, description, urls };
            return entitiesJson;
        }
    }
   
    public class ResultObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
