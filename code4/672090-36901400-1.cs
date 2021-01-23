    using System;
    using Newtonsoft.Json;
    namespace Utilities
    {
        public static class serializer
        {
            public static string SerializeObject(object objectModel) {
                return JsonConvert.SerializeObject(objectModel);
            }
            public static object DeserializeObject<T>(string jsonObject)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(jsonObject);
                }
                catch (Exception ex) { return null; }
                
            }
        }
    }
