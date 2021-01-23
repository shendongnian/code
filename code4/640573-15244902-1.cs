    public abstract class BaseConfiguration<T> : EntityTypeConfiguration<T>
        where T: class
    {
        private readonly string defaultTableMap = "tbl_X_" + typeof(T).Name;
        
        public BaseConfiguration(): this(defaultTableMap) { }
        public BaseConfiguration(string tableMap)
        {
            Map(x => x.ToTable(tableMap));
            var parm = Expression.Parameter(typeof(T), typeof(T).Name);
            var propExpression = Expression.Lambda<Func<T, int>>
                (Expression.Convert(Expression.Property(parm, "Id"), typeof(int)), parm);
            Property(propExpression).HasColumnName(typeof(T).Name + "_ID");
        }
    }
