    using System;
    using System.Dynamic;
    using System.Text;
    static class Program {
        static void Main() {
            dynamic test = new Test();
            var result = test.Posts.Foo.Bar(123, "abc");
            Console.WriteLine(result);
        }
    }
    public class Test : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder,
            out object result)
        {
            result = new MemberAccessWrapper("member accessed was " + binder.Name);
            return true;
        }
        private class MemberAccessWrapper : DynamicObject
        {
            private readonly string message;
            public override bool TryInvoke(InvokeBinder binder, object[] args,
                out object result)
            {
                StringBuilder builder = new StringBuilder(message).Append("(");
                for(int i = 0 ; i < args.Length ; i++) {
                    if(i!=0)builder.Append(", ");
                    if (args[i] == null) {
                        builder.Append("null");
                    } else if (args[i] is string) {
                        builder.Append("@\"").Append(((string)args[i])
                             .Replace("\"", "\"\"")).Append("\"");
                    } else {
                        builder.Append(args[i]);
                    }
                }
                builder.Append(")");
                result = new MemberAccessWrapper(builder.ToString());
                return true;
            }
            public MemberAccessWrapper(string message)
            {
                this.message = message;
            }
            public override string ToString()
            {
                return message;
            }
            public override bool TryGetMember(GetMemberBinder binder,
                out object result)
            {
                result = new MemberAccessWrapper(message + "." + binder.Name);
                return true;
            }
        }
    }
