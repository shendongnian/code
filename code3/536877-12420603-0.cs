        public string ResolveProperty<TEntity,TReturn>(Expression<Func<TEntity, TReturn>> prop)
        {
            if (prop.Body is MemberExpression) {
                return ((MemberExpression)prop.Body).Member.Name;
            }
            else {
                var op = ((UnaryExpression)prop.Body).Operand;
                return ((MemberExpression)op).Member.Name;
            }                
        }
