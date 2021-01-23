    using Extensions;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var subjects = default(List<Pandora.Data.DomainObject>);
                var result = Helper<List<Pandora.Data.DomainObject>>.ExampleFunction(() => subjects);
            }
        }
    }
    namespace Extensions
    {
        static class Helper<T>
        {
            public static List<string> ExampleFunction(Expression<Func<T>> f)
            {
                if ((f.Body as MemberExpression).Member.Name == "subjects")
                {
                    return new List<String>();
                }
                return null;
            }
        }
    }
