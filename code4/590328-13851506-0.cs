    public static class MyCustomNamingConvention
    {
        public static void ToMyDatabaseNamingConvention(
            this DbModelBuilder mb, IEnumerable<Type> entities)
        {
            foreach (var entity in entities)
            {
                var name = entity.Name.Replace("Entity", "");
    
                var mi = typeof(MyCustomNamingConvention)
                    .GetMethod("MyNamingConvention")
                    .MakeGenericMethod(entity);
                mi.Invoke(null, new object[] { mb, name });
            }
        }
    
        public static void MyNamingConvention<T>
            (DbModelBuilder mb, string tableName) where T : Entity
        {
            mb.Entity<T>().HasKey(x => x.Id);
            mb.Entity<T>().Property(x => x.Id).HasColumnName(tableName + "Id");
            mb.Entity<T>().ToTable(tableName);
        }
    
    }
