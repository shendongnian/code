     public static string ToJSONString<T>(this IEnumerable<T> items)
       {
            var jsonString =  JsonConvert.SerializeObject(items, Formatting.Indented, new JsonSerializerSettings
                {
                    ContractResolver = new LowerCaseContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });
            jsonString = jsonString.Replace("\r\n", string.Empty);
            return jsonString;
        }
