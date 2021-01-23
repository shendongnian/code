    class Server
    {
        protected static List<Type> DTOList = new List<Type>(); 
        static void Main()
        {
            DTOList.Add(typeof(JSONProfileDTO));
            DTOList.Add(typeof(JSONCommandDTO));
            DTOList.Add(typeof(JSONMessageDTO));
        }
        protected static void OnMessage (string rawString)
        {
            dynamic jsonObject = null;
            int DTOCount = DTOList.Count;
            int errors = 0;
            var settings = new JsonSerializerSettings ();
            // This was important
            // Now exception is thrown when creating invalid instance in the loop
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            foreach (Type DTOType in DTOList) {
                try {
                    jsonObject = JsonConvert.DeserializeObject (rawString, DTOType, settings);
                    break;
                } catch (Exception ex) {
                    errors++;
                }
            }
            if (null == jsonObject) {
                return;
            }
            if (errors == DTOCount) {
                return;
            }
            if (jsonObject is JSONProfileDTO) {
                AssignProfile((JSONProfileDTO) jsonObject);
            }
            else if (jsonObject is JSONCommandDTO)
            {
                RunCommand((JSONCommandDTO) jsonObject);
            }
        }
    }
