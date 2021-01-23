    public static class DataContextHelpers
    {
        public static T GetByPk<T>(this DataContext context, object pk) where T : class {
            var table = context.GetTable<T>();
            var mapping = context.Mapping.GetTable(typeof(T));
            var pkfield = mapping.RowType.DataMembers.SingleOrDefault(d => d.IsPrimaryKey);
            if (pkfield == null)
                throw new Exception(String.Format("Table {0} does not contain a Primary Key field", mapping.TableName));
            var param = Expression.Parameter(typeof(T), "e");
            var predicate = Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Property(param, pkfield.Name), Expression.Constant(pk)), param);
            return table.SingleOrDefault(predicate);
        }
    }
