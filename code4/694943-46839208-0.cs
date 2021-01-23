    using System.IO;
    using Nancy;
    using Newtonsoft.Json;
    
    namespace NancyFx
    {
        public static class DynamicModelBinder
        {
            public static dynamic ToDynamic(this NancyContext context)
            {
                var serializer = new JsonSerializer();
                using (var sr = new StreamReader(context.Request.Body))
                {
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        return serializer.Deserialize(jsonTextReader);
                    }
                }
            }
        }
    }
