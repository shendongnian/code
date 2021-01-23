    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class FieldTypeAttribute : Attribute
    {
        public FieldTypeAttribute(Type type)
        {
            Type = type;
        }
        public Type Type { get; set; }
    }
    public static class FieldTypeInfo<TEnum> where TEnum : struct
    {
        public static readonly IDictionary<TEnum, FieldTypeAttribute> Types;
        static FieldTypeInfo()
        {
            var enumTypes = from e in Enum.GetValues(typeof (TEnum)).Cast<TEnum>()
                join m in typeof (TEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
                    on e.ToString() equals m.Name
                let i = m.GetCustomAttributes().OfType<FieldTypeAttribute>().SingleOrDefault()
                select new {e, i};
            Types = enumTypes.ToDictionary(es => es.e, es => es.i);
        }
    }
