    public static class EdmxExtensions
    {
       [EdmFunction("SqlServer", "STR")]
       public static string StringConvert(decimal? number, int? length)
       {
          throw EntityUtil.NotSupported(Strings.ELinq_EdmFunctionDirectCall);
       }
       public static IQueryable<Person> MyFunction(this IDbContext context, decimal? number, int? length)
       {
          context.Person.Where(s => StringConvert(s.personId, number, length);
       }
