    public static class ExceptByProperty
    {
        public static List<T> ExceptBYProperty<T, TProperty>(this List<T> list, List<T> list2, Expression<Func<T, TProperty>> propertyLambda)
        {
            Type type = typeof(T);
            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));
            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));
            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));
            Func<T, TProperty> func = propertyLambda.Compile();
            var ids = list2.Select<T, TProperty>(x => func(x)).ToArray();
            return list.Where(i => !ids.Contains(((TProperty)propInfo.GetValue(i, null)))).ToList();
        }
    }
    public class testClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
