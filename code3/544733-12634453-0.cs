    using System;
    using System.Dynamic;
    static class Program {
        static void Main() {
            dynamic test = new Test();
            var result = test.Posts.Foo.Bar;
            Console.WriteLine(result);
        }
    }
    public class Test : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder,
            out object result)
        {
            result = new MemberAccessWrapper("member accessed was "
                            + binder.Name);
            return true;
        }
        private class MemberAccessWrapper : DynamicObject
        {
            private readonly string message;
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
