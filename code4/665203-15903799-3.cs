    public static class responseExtensions
    {
      private static IEnumerable<Field> GetFields(this response target)
      {
        var fields = target.GetType().GetFields().Where(f => f.FieldType == typeof(Field));
        return from f in fields
               let fp = f.GetValue(target) as Field
               where fp != null
               select fp;
      }
    }
