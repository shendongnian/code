    public static class ExtMethods
    {
        public static JObject DumpPretty(this JObject jo)
        {
            var jsonString = JsonConvert.SerializeObject(jo);
            JsonConvert.DeserializeObject<ExpandoObject>(jsonString).Dump();
            
            return jo;  // return input in the spirit of LINQPad's Dump() method.
        }
    }
