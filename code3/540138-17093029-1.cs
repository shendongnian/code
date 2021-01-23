    private static Func<IDataReader, object> GetStructDeserializer(Type type, Type effectiveType, int index)
    //some if cases above
    if (type == typeof(DateTime))
    {
        return r =>
        {
            var val = r.GetValue(index);
            return val is DBNull ? null : (object)new DateTime(((DateTime)val).Ticks, DateTimeKind.Utc);
        };
    }
    //default case below - which was earlier getting used for DateTime
