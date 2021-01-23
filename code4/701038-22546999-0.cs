    using System.ComponentModel;
    using System.Reflection;
    using MyExtensions;
    
    namespace MyExtensions
    {
        public static class Extension
        {
            public static string GetDescriptionName(this Enum value)
            {
                Type type = value.GetType();
                string name = Enum.GetName(type, value);
                if (name == null)
                    return null;
                else
                {
                    FieldInfo field = type.GetField(name);
                    if (field == null)
                        return name;
                    else
                    {
                        DescriptionAttribute attr =
                                Attribute.GetCustomAttribute(field,
                                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                        if (attr == null)
                            return name;
                        else
                            return attr.Description;
                    }
                }
            }
        }
    }
    
    namespace EnumDescription
    {
        class Program
        {
            public enum enumDateCond : byte 
            {
                [Description("Empty")]
                Null = 0,
                [Description("Not Empty")]
                NotNull = 1,
                EQ = 2, 
                LT = 3, 
                LE = 4, 
                GE = 14, 
                GT = 15 
            };
            static void Main(string[] args)
            {
                enumDateCond x = enumDateCond.Null;
                string description = x.GetDescriptionName();
                foreach (enumDateCond enm in Enum.GetValues(typeof(enumDateCond)))
                {
                    description = enm.GetDescriptionName();
                    Console.WriteLine(description);
                }
                Console.WriteLine("Dictionary");
                Dictionary<enumDateCond, string> DLenumDateCond = EnumToDictionary<enumDateCond>();
                foreach(enumDateCond key in DLenumDateCond.Keys)
                {
                    Console.WriteLine(key.ToString() + " " + DLenumDateCond[key]);
                }
            }
            public static Dictionary<T, string> EnumToDictionary<T>()
                where T : struct
            {
                Type enumType = typeof(T);
    
                // Can't use generic type constraints on value types,
                // so have to do check like this
                if (enumType.BaseType != typeof(Enum))
                    throw new ArgumentException("T must be of type System.Enum");
    
                Dictionary<T, string> enumDL = new Dictionary<T, string>();
                foreach (T enm in Enum.GetValues(enumType))
                {
                    string name = Enum.GetName(enumType, enm);
                    if (name != null)
                    {
                        FieldInfo field = enumType.GetField(name);
                        if (field != null)
                        {
                            DescriptionAttribute attr =
                                    Attribute.GetCustomAttribute(field,
                                        typeof(DescriptionAttribute)) as DescriptionAttribute;
                            if (attr != null)
                                name = attr.Description;
                        }
                    }
                    enumDL.Add(enm, name);
                }
                return enumDL;
            }
        }
    }
