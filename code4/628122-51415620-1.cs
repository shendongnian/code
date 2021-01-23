        public static object ToCollections(object o)
        {
            var jo = o as JObject;
            if (jo != null) return jo.ToObject<IDictionary<string, object>>().ToDictionary(k => k.Key, v => ToCollections(v.Value));
            var ja = o as JArray;
            if (ja != null) return ja.ToObject<List<object>>().Select(ToCollections).ToList();
            return o;
        }
