    using System;
    namespace Demo
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                var demo = new ImmutableClass.Builder{
                    A = 1,
                    B = "two",
                    C = 3.0
                }.Build();
            }
        }
        public sealed class ImmutableClass
        {
            public sealed class Builder
            {
                public int A;
                public string B;
                public double C;
                public ImmutableClass Build()
                {
                    return new ImmutableClass(this);
                }
            }
            private ImmutableClass(Builder builder)
            {
                _a = builder.A;
                _b = builder.B;
                _c = builder.C;
            }
            public int A
            {
                get
                {
                    return _a;
                }
            }
            public string B
            {
                get
                {
                    return _b;
                }
            }
            public double C
            {
                get
                {
                    return _c;
                }
            }
            private readonly int _a;
            private readonly string _b;
            private readonly double _c;
        }
    }
