    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DbTypeAttribute : Attribute
    {
        public DbType DbType { get; private set; }
        public DbTypeAttribute(DbType dbType)
        {
            this.DbType = dbType;
        }
    }
    public static class DbHelper<T> where T : IComparable, IFormattable, IConvertible, struct
    {
        private static Dictionary<long, DbType> _dbTypeLookup = CreateLookup();
        public static DbType GetColumnType(T column)
        {
            return _dbTypeLookup[(long)(object)column];
        }
        private static Dictionary<long, DbType> CreateLookup()
        {   
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("T must be an enum type.");
            
            var dbTypeLookup = new Dictionary<long, DbType>();
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                var enumMember = typeof(T).GetMember(name).Single();
                var dbTypeAttr = (DbTypeAttribute)enumMember.GetCustomAttributes(typeof(DbTypeAttribute), false).Single();
                dbTypeLookup.Add((long)Enum.Parse(typeof(T), name), dbTypeAttr.DbType);
            }
            return dbTypeLookup;
        }
    }
