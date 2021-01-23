        public class A
        {
            public bool Thing1 { get; set; }
            public bool Thing2 { get; set; }
        }
        static void Main(string[] args)
        {
            var @as = new A[10];
            for(var i = 0; i < @as.Length; i+=2)
            {
                @as[i] = new A {Thing1 = true};
                @as[i + 1] = new A {Thing2 = i%4 == 0};
            }
            var thing1Expression = ExpressionCreator.CreatePropertyAccessExpression<A, bool>("Thing1");
            var thing2Expression = ExpressionCreator.CreatePropertyAccessExpression<A, bool>("Thing2");
            Console.WriteLine(@as.Count(thing1Expression));
            Console.WriteLine(@as.Count(thing2Expression));
            Console.ReadLine();
        }
