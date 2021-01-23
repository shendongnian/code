    public static class CustomExtensions
      {
        public static string GetLabel(this ECategory value)
        {
          Type type = value.GetType();
          string name = Enum.GetName(type, value);
          if (name != null)
          {
            FieldInfo field = type.GetField(name);
            if (field != null)
            {
              LabelAttribute attr = Attribute.GetCustomAttribute(field, typeof(LabelAttribute )) as LabelAttribute ;
              if (attr != null)
              {
                return attr.Name;
              }
            }
          }
          return null;
        }
      }
