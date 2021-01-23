    public static class ObjExt
    {
        public static void Trim<T>(this T item)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in properties)
            {
                if (p.PropertyType != typeof(string) || !p.CanWrite || !p.CanRead) { continue; }
                var value = p.GetValue(item) as string;
                p.SetValue(item,value.Trim());
            }
        }
    }
