    static class JsonNetDumper {
      public static IEnumerable<IDictionary<string, object>> ToDumpable(this IEnumerable<object> rg) { 
        return rg.Cast<JObject>().Select(o => o.Properties().ToDictionary(p => p.Name, p => (object)p.Value));
      }
    }
