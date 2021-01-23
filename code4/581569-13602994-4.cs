    static void PrintObject(object instance, int initialIndentLevel)
    {
        PrintObject(instance, initialIndentLevel, 4, ' ', new List<object>());
    }
    static void PrintObject(object instance, int level, int indentCount, char paddingChar, ICollection<object> printedObjects)
    {
        if (printedObjects.Contains(instance))
        {
            return;
        }
        var tabs = "".PadLeft(level * indentCount, paddingChar);
        var instanceType = instance.GetType();
        printedObjects.Add(instance);
            
        foreach (var member in instanceType.GetMembers())
        {
            object value;
            try
            {
                switch (member.MemberType)
                {
                    case MemberTypes.Property:
                        var property = (PropertyInfo) member;
                        value = property.GetValue(instance, null);
                        break;
                    case MemberTypes.Field:
                        var field = (FieldInfo) member;
                        value = field.GetValue(instance);
                        break;
                    default:
                        continue;
                }
            }
            catch
            {
                continue;
            }
            if (value == null || value.GetType().IsValueType || value.GetType().ToString() != value.ToString())
            {
                Console.WriteLine("{2}{0}: {1}", member.Name, (value ?? "(null)"), tabs);
            }
            else
            {
                var vals = value as IEnumerable;
                if (vals != null)
                {
                    var index = 0;
                    var indented = "".PadLeft((level + 1) * indentCount, paddingChar);
                    Console.WriteLine("{2}{0}: {1}", member.Name, value, tabs);
                    foreach (var val in vals)
                    {
                        Console.WriteLine("{1}[{0}]:", index++, indented);
                        PrintObject(val, level + 2, indentCount, paddingChar, printedObjects);
                    }
                    if (index == 0)
                    {
                        Console.WriteLine("{0}(No elements)", indented);
                    }
                }
                else
                {
                    PrintObject(value, level + 1, indentCount, paddingChar, printedObjects);
                }
            }
        }
    }
