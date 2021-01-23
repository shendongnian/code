    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    class Foo
    {
        public string Forename {get;set;}
    }
    class Test<T>
    {
        public void Do(object target, object value)
        {
            var obj = Expression.Constant(target, typeof(T));
            var member = Expression.PropertyOrField(obj, "Forename");
            var param = Expression.Parameter(typeof(object));
            Type type;
            switch(member.Member.MemberType)
            {
                case MemberTypes.Field:
                    type = ((FieldInfo)member.Member).FieldType; break;
                case MemberTypes.Property:
                    type = ((PropertyInfo)member.Member).PropertyType; break;
                default:
                    throw new NotSupportedException(member.Member.MemberType.ToString());
            }
            var body = Expression.Assign(member, Expression.Convert(param, type));
            var lambda = Expression.Lambda<Action<object>>(body, param);
            lambda.Compile()(value);
        }
    }
    static class Program
    {
        static void Main()
        {
            var obj = new Foo();
            new Test<Foo>().Do(obj, "abc");
            Console.WriteLine(obj.Forename);
        }
    }
