    using Newtonsoft.Json;
    static class JsonObj
    {
        /// <summary>
        /// Deserializes a json file into an object list
        /// Author: Joseph Poirier 2/26/2019
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<T> DeSerializeObject<T>(string fileName)
        {
            List<T> objectOut = new List<T>();
            if (string.IsNullOrEmpty(fileName)) { return objectOut; }
            
            try
            {
                // reading in full file as text
                string ss = File.ReadAllText(fileName);
                // went with <dynamic> over <T> or <List<T>> to avoid error..
                //  unexpected character at line 1 column 2
                var output = JsonConvert.DeserializeObject<dynamic>(ss);
    
                foreach (var Record in output)
                {
                    foreach (T data in Record)
                    {
                        objectOut.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception here
                Console.Write(ex.Message);
            }
            return objectOut;
        }
    }
