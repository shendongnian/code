        /// <summary>
        /// Returns string representation of object property states i.e. Name: Jim, Age: 43
        /// </summary>
        public static string GetPropertyStateList(this object obj)
        {
            if (obj == null) return "Object null";
    
            var sb = new StringBuilder();
            var enumerable = obj as IEnumerable;
    
            if (enumerable != null)
            {
                foreach (var listitem in enumerable)
                {
                    sb.AppendLine();
                    sb.Append(ReadProperties(listitem));
                }
            }
            else
            {
                sb.Append(ReadProperties(obj));
            }
    
            return sb.ToString();
        }
    
        private static string ReadProperties(object obj)
        {
            var sb = new StringBuilder();
            var propertyInfos = obj.GetType().GetProperties().OrderBy(x => x.Name).Where(x=>!x.GetIndexParameters().Any());
    
            foreach (var prop in propertyInfos)
            {
                var value = prop.GetValue(obj, null) ?? "(null)";
                sb.AppendLine(prop.Name + ": " + value);
            }
    
            return sb.ToString();
        }
  
