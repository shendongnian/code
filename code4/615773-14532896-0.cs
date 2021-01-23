    public class api_data {
        public class sessions {
            public string id { get; set; }
            public string sessionID { get; set; }
            // put all the other vars in here ...
        }
        public string status { get; set; }           
        public List<sessions> session_list { get; set; }
        public static api_data LoadFromXML(string xmlFile) {
            api_data localApiData;
            // serialize from file
            try {
                var xs = new XmlSerializer(typeof(api_data),
                         new XmlRootAttribute("api_data"));
                using (TextReader tr = new StreamReader(xmlFile)) {
                    localApiData= xs.Deserialize(tr) as api_data;
                }
            }
            catch (Exception ex) {
                Log.LogError(string.Format(
                   "Error reading api_data file {0}: {1}",
                   xmlFile, ex.Message));
                return null;
            }
            return localApiData;
        }
    }
