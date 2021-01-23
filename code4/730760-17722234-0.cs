    public class BaseClass<T> {
        public static string GetPropertyName<P>(Expression<Func<T, P>> action) {
            MemberExpression expression = action.Body as MemberExpression;
            return expression.Member.Name;
        }
    }
    public class ClassOne : BaseClass<ClassOne> {
        public string PropertyOne { get; set; }
    }
    public static class Test {
        public static void test() {
            var displayMember = ClassOne.GetPropertyName(x => x.PropertyOne);
        }
    }
