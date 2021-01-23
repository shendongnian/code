    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    
    static class Program
    {
        public static string GetString()
        {
            return "single1";
        }
        public static string[] GetStrings()
        {
            return new[]
            {
                "first",
                "second",
                "third"
            };
        }
        static void Main()
        {
            var expressions = new List<Expression>
            {
                Expression.Call(typeof(Program).GetMethod("GetString")),
                Expression.Call(typeof(Program).GetMethod("GetStrings")), 
                Expression.Call(typeof(Program).GetMethod("GetString")),
                Expression.Call(typeof(Program).GetMethod("GetStrings"))
            };
    
            // some magic code here
            var combined = SomeMagicHere(expressions);
    
            // show it works
            var lambda = Expression.Lambda<Func<List<string>>>(combined);
            var list = lambda.Compile()();
        }
        private static Expression SomeMagicHere(List<Expression> expressions)
        {
            List<Expression> blockContents = new List<Expression>();
            var var = Expression.Variable(typeof(List<string>), "list");
            blockContents.Add(Expression.Assign(var,
                Expression.New(typeof(List<string>))));
            foreach (var expression in expressions)
            {
                if (expression.Type.IsArray)
                {
                    blockContents.Add(Expression.Call(
                        var, var.Type.GetMethod("AddRange"), expression));
                }
                else
                {
                    blockContents.Add(Expression.Call(var,
                        var.Type.GetMethod("Add"), expression));
                }
            }
            blockContents.Add(var); // last statement in a block is the effective
                                    // value of the block
            return Expression.Block(new[] {var}, blockContents);
        }
        
    }
