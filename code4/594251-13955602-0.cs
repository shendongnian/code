    public static class OneWaySerializer
    {
        public static String OneWaySerialize(this Object obj)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} {{", obj.GetType().FullName).AppendLine();
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (var prop in properties)
            {
                Object propVal = prop.GetValue(obj);
                result.AppendFormat("{0} = {1}", prop.Name, propVal).AppendLine();
            }
            // ...
            result.AppendLine("}");
            return result.ToString();            
        }
    }
    someDefinedObject.OneWaySerialize();
