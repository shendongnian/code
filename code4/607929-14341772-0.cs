     private T GetById(int id, IQueryable<T> list)
        {
            var itemParameter = Expression.Parameter(typeof(T), "item");
            var whereExpression = Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal(
                    Expression.Property(
                        itemParameter,
                        PrimaryKeyName
                        ),
                    Expression.Constant(id)
                    ),
                new[] { itemParameter }
                );
            var item = list.Where(whereExpression).SingleOrDefault();
            if (item == null)
            {
                throw new PrimaryKeyNotFoundException(string.Format("No {0} with primary key {1} found",
                                                                    typeof(T).FullName, id));
            }
            return item;
        }
