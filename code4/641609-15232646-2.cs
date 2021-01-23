    public static void PrintProperties(object obj, int indent = 4, char intendCharacter = ' ')
        {
            if (obj == null) return;
            string indentString = new string(intendCharacter, indent);
            Type objType = obj.GetType();
            foreach (var pName in GetPropertiesToLogWithCaching(obj))
            {
                var property = objType.GetProperty(pName);
                object propValue = property.GetValue(obj, null);
                if (property.PropertyType.Assembly == objType.Assembly)
                {
                    Console.WriteLine("{0}{1}:", indentString, property.Name);
                    PrintProperties(propValue, indent + 2);
                }
                else
                {
                    Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
                }
            }            
        }
