        public static Expression<Func<TEntity, bool>> MakeDateRange<TEntity>(DateTime? dateFrom, DateTime? dateTo)
        {
            var et = typeof(TEntity);
            var param = Expression.Parameter(et, "a");
            var prop = et.GetProperty("UpdatedDate");
            Expression body = null, left = null, right = null;
            if (prop == null)
            {
                prop = et.GetProperty("CreatedDate");
                if (prop == null)
                {
                    prop = et.GetProperty("Date");
                }
            }
            if (dateFrom.HasValue)
            {
                left = Expression.GreaterThanOrEqual(Expression.PropertyOrField(param, prop.Name), Expression.Constant(dateFrom.GetValueOrDefault()));
            }
            if (dateTo.HasValue)
            {
                right = Expression.LessThanOrEqual(Expression.PropertyOrField(param, prop.Name), Expression.Constant(dateTo.GetValueOrDefault()));
            }
            if (left != null && right != null)
            {
                body = Expression.AndAlso(left, right);
            }
            else if (left != null)
            {
                body = left;
            }
            else
            {
                body = right;
            }
            return Expression.Lambda<Func<TEntity, bool>>(body, param);
        }
