    public class Parent {
        public string StringProperty { get; set; }
        public Child Child { get; set; }
    }
    public class Child {
        public int IntProperty { get; set; }
    }
    internal class Program {
        private static void Main(string[] args) {
            var p = new Parent { Child = new Child() };
            var param = Expression.Parameter(typeof(Parent), "param");
            var accessExpression = GetAccessExpression(param, "Child.IntProperty", typeof(Parent));
            Console.WriteLine(accessExpression.ToString());
            Console.ReadLine();
        }
        /// <summary>
        /// Returns an Expression that represents member access for the specified property on the specified type. Uses recursion
        /// to find the full expression.
        /// </summary>
        /// <param name="property">The property path.</param>
        /// <param name="type">The type that contains the first part of the property path.</param>
        /// <returns></returns>
        private static Expression GetAccessExpression(Expression param, string property, Type type) {
            if (property == null)
                throw new ArgumentNullException("property");
            if (type == null)
                throw new ArgumentNullException("type");
            string[] propPath = property.Split('.');
            var propInfo = type.GetProperty(propPath[0]);
            if (propInfo == null)
                throw new Exception(String.Format("Could not find property '{0}' on type {1}.", propPath[0], type.FullName));
            var propAccess = Expression.MakeMemberAccess(param, type.GetProperty(propPath[0]));
            if (propPath.Length > 1)
                return GetAccessExpression(propAccess, string.Join(".", propPath, 1, propPath.Length - 1), type.GetProperty(propPath[0]).PropertyType);
            else
                return propAccess;
        }
    }
