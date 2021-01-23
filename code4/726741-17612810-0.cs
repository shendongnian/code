    public static class Extensions
    {
        public static string Format(this object data, string format)
        {
            var values = new List<object>();
            var type = data.GetType();
            format = Regex.Replace(format, @"(^|[^{])\{([^{}]+)\}([^}]|$)", x =>
            {
                var keyValues = Regex.Split(x.Groups[2].Value,
                                            "^([^:]+):?(.*)$")
                                        .Where(y => !string.IsNullOrEmpty(y));
                var key = keyValues.ElementAt(0);
                var valueFormat = keyValues.Count() > 1 ?
                                    ":" + keyValues.ElementAt(1) :
                                    string.Empty;
                var value = GetValue(key, data, type);
                values.Add(value);
                return string.Format("{0}{{{1}{2}}}{3}", 
                                        x.Groups[1].Value, 
                                        values.Count - 1, 
                                        valueFormat, 
                                        x.Groups[3].Value);
            });
            return string.Format(format, values.ToArray());
        }
        private static object GetValue(string name, object data, Type type)
        {
            var info = type.GetProperty(name);
            return info.GetValue(data, new object[0]);
        }
    }
