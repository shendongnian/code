        class Foo
        {
            public int a { get; set; }
            public int b { get; set; }
            public int c { get; set; }
        }
        static bool VerifyRule(Foo obj, string rule)
        {
            NCalc.Expression expr = new NCalc.Expression(rule);
            expr.EvaluateParameter += (name, args) =>
            {
                args.Result = typeof(Foo).GetProperty(name).GetValue(obj, null);
            };
            return (bool)expr.Evaluate();
        }
        // USAGE EXAMPLE
        static void Main(string[] args)
        {
            var foo1 = new Foo() { a = 3, b = 4, c = 12 };
            var foo2 = new Foo() { a = 1, b = 4, c = 12 };
            // verify rules
            var res1 = VerifyRule(foo1, "a == 3 && b == 4"); // returns true
            var res2 = VerifyRule(foo2, "a == 3 && b == 4"); // returns false
            // more complex rules:
            var res3 = VerifyRule(foo1, "(a < 4 && b > 5) || c == 12"); // returns true
            var res4 = VerifyRule(foo1, "a + b == 7"); // returns true
        }
        
