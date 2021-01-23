    XNamespace ns = "http://www.opengis.net/kml/2.2";
    var items = xDoc.Descendants(ns + "Style")
                    .Select(d => new
                    {
                       Id = d.Attribute("id").Value,
                       HRef = d.Descendants(ns + "href").FirstOrDefault()
                                                        .IfNotNull(h=>h.Value)
                    })
                    .ToList();
    public static class S_O_Extensions
    {
        public static S IfNotNull<T, S>(this T obj,Func<T,S> selector)
        {
            if (obj == null) return default(S);
            return selector(obj);
        }
     }
