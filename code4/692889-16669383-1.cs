    public static T GetEnumValueFromDescription<T>(string description)
            {
                var type = typeof(T);
                if (!type.IsEnum)
                    throw new ArgumentException();
    
                FieldInfo[] fields = type.GetFields();
                var field = fields.SelectMany(f => f.GetCustomAttributes(
                                    typeof(CodeAttribute), false), (
                                        f, a) => new { Field = f, Att = a })
                                .Where(a => ((CodeAttribute)a.Att)
                                    .Code == description).SingleOrDefault();
                return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
            }
