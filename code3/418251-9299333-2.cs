    public static class MyExtensions
    {
        public static string ToStringExtension(this object obj)
        {
            StringBuilder sb = new StringBuilder();
            foreach (System.Reflection.PropertyInfo property in obj.GetType().GetProperties())
            {
                sb.Append(property.Name);
                sb.Append(": ");
                sb.Append(property.GetValue(obj, null));
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }
