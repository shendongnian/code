    static void Copy(RouteCollection source, RouteCollection dest)
        {
            Dictionary<string, RouteBase> _namedMap = typeof(RouteCollection).GetField("_namedMap", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(source) as Dictionary<string, RouteBase>;
            for (int i = 0; i < source.Count; i++)
            {
                var item = source[i];
                string name = _namedMap.Where(r => object.Equals(item, r.Value)).Select(r => r.Key).FirstOrDefault();
                dest.Add(name, item);
            }
        }
