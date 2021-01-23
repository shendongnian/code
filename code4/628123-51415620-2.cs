        public static object ToCollections(object o)
        {
            if (o is JObject jo) return jo.ToObject<IDictionary<string, object>>().ToDictionary(k => k.Key, v => ToCollections(v.Value));
            if (o is JArray ja) return ja.ToObject<List<object>>().Select(ToCollections).ToList();
            return o;
        }
