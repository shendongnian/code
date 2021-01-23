    internal class AutoMapperSelectStrategy<TEntity, TIdentity> :
        IIdentitySelectStrategy<TEntity, TIdentity>
    {
        private IMappingEngine mappingEngine;
        internal AutoMapperSelectStrategy(
            IMappingEngine<TEntity, TIdentity> mappingEngine)
        {
            this.mappingEngine = mappingEngine;
        }
        public Expression<Func<TEntity, bool>> GetPredicateForIdentity(
            TIdentity identity)
        {
            var entityParameter = Expression.Parameter(typeof(TEntity));
            var identityScope = Expression.MakeMemberAccess(
                Expression.Constant(
                    new ExpressionScope<TIdentity>() { Value = identity }),
                    typeof(ExpressionScope<TIdentity>).GetProperty("Value"));
            var equalityExpressions = this.MakeEqualityExpressions(
                identityScope, entityParameter);
            var aggregateEquality = equalityExpressions.Aggregate(
                (x, y) => Expression.AndAlso(x, y));
            var predicate = Expression.Lambda<Func<TEntity, bool>>(
                aggregateEquality, entityParameter);
            return predicate;
        }
        public IEnumerable<BinaryExpression> MakeEqualityExpressions(
            MemberExpression identityScope, ParameterExpression entityParameter)
        {
            var mapExpression =
                mappingEngine.CreateMapExpression<TIdentity, TEntity>();
            var body = mapExpression.Body as MemberInitExpression;
            var bindings = body.Bindings;
            foreach (var binding in bindings.OfType<MemberAssignment>())
            {
                var memberExpression = binding.Expression as MemberExpression;
                var left = Expression.Property(
                    identityScope, memberExpression.Member as PropertyInfo);
                var right = Expression.Property(
                    entityParameter, binding.Member as PropertyInfo);
                var equalityExpression = Expression.Equal(left, right);
                yield return equalityExpression;
            }
        }
        private class ExpressionScope<TDto>
        {
            public TDto Value { get; set; }
        }
    }
