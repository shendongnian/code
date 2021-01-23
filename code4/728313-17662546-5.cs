    static void InitializeData1(IList objects, PropertyInfo[] props, List<Dictionary<string, object>> tod) {
        foreach(var item in objects) {
            var kvp = new Dictionary<string, object>();
            foreach(var p in props) {
                kvp.Add(p.Name, p.GetValue(item, null));
            }
            tod.Add(kvp);
        }
    }
