        public static T With<T, P>(this T self, Expression<Func<T, P>> selector, P newValue)
        {
            var me = (MemberExpression)selector.Body;
            var changedProp = (System.Reflection.PropertyInfo)me.Member;
            var constructor = typeof(T).GetConstructors()[0];
            var parameters = constructor.GetParameters().Select(p => p.Name);
            var properties = typeof(T).GetProperties();
            var args = parameters
                .Select(p => properties.FirstOrDefault(prop => String.Equals(prop.Name,p, StringComparison.CurrentCultureIgnoreCase)))
                .Select(prop => prop == changedProp ? newValue : prop.GetValue(self))
                .ToArray();
            var clone = (T) constructor.Invoke(args);
            return clone;
        }
