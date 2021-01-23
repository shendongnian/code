    static IEnumerable<Tuple<TEnum, TAttribute>> GetEnumAttributes<TEnum, TAttribute>()
      where TEnum : struct
      where TAttribute : Attribute {
      return typeof(TEnum)
        .GetFields(BindingFlags.Static | BindingFlags.Public)
        .Where(fieldInfo => Attribute.IsDefined(fieldInfo, typeof(TAttribute)))
        .Select(
          fieldInfo => Tuple.Create(
            (TEnum) fieldInfo.GetValue(null),
            (TAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof(TAttribute))
          )
        );
    }
