    public static string ConvertToString(this object obj)
    {
       Type type = obj.GetType();
       var properties = 
             type.GetProperties()
                 .Where(p => !p.GetIndexParameters().Any())
                 .Select(p => p.GetValue(obj, null))
                 .Select(x => String.Format("\"{0}\"", (x == null) ? "null" : x));
       return String.Format("{{{0}}}", String.Join(", ", properties));
    }
