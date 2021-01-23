            String abc = JsonConvert.SerializeObject(all, Formatting.None, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Objects,
                            TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                        });
            return abc;
        }
         public Dictionary<int, Dictionary<String, String>> DeSerialize(String text)
         {
             Dictionary<int, Dictionary<String, String>> abc;
             abc = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<String, String>>>(text, new JsonSerializerSettings
             {
                 TypeNameHandling = TypeNameHandling.Objects,
                 TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
             });
             return abc;
         }
           
