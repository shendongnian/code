        static void Main(string[] args)
        {
            double acc = 0;
            var il = ILFact();
            il.Invoke(1);
            var et = ETFact();
            et(1);
            Stopwatch sw = new Stopwatch();
            for (int k = 0; k < 10; k++)
            {
                long time1, time2;
                sw.Restart();
                for (int i = 0; i < 30000; i++)
                {
                    var result = CSharpFact(i);
                    acc += result;
                }
                sw.Stop();
                time1 = sw.ElapsedMilliseconds;
                sw.Restart();
                for (int i = 0; i < 30000; i++)
                {
                    double result = il.Invoke(i);
                    acc += result;
                }
                sw.Stop();
                time2 = sw.ElapsedMilliseconds;
                sw.Restart();
                for (int i = 0; i < 30000; i++)
                {
                    var result = et(i);
                    acc += result;
                }
                sw.Stop();
                Console.WriteLine("{0,6} {1,6} {2,6}", time1, time2, sw.ElapsedMilliseconds);
            }
            Console.WriteLine("\n{0}...\n", acc);
            Console.ReadLine();
        }
        static Func<int, int> ILFact()
        {
            var method = new DynamicMethod(
            "factorial", typeof(int),
            new[] { typeof(int) }
            );
            var il = method.GetILGenerator();
            var result = il.DeclareLocal(typeof(int));
            var startWhile = il.DefineLabel();
            var returnResult = il.DefineLabel();
            
            // result = 1
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Stloc, result);
            // if (value <= 1) branch end
            il.MarkLabel(startWhile);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Ble_S, returnResult);
            // result *= (value--)
            il.Emit(OpCodes.Ldloc, result);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Sub);
            il.Emit(OpCodes.Starg_S, 0);
            il.Emit(OpCodes.Mul);
            il.Emit(OpCodes.Stloc, result);
            // end while
            il.Emit(OpCodes.Br_S, startWhile);
            // return result
            il.MarkLabel(returnResult);
            il.Emit(OpCodes.Ldloc, result);
            il.Emit(OpCodes.Ret);
            return (Func<int, int>)method.CreateDelegate(typeof(Func<int, int>));
        }
        static Func<int, int> ETFact()
        {
            // Creating a parameter expression.
            ParameterExpression value = Expression.Parameter(typeof(int), "value");
            // Creating an expression to hold a local variable. 
            ParameterExpression result = Expression.Parameter(typeof(int), "result");
            // Creating a label to jump to from a loop.
            LabelTarget label = Expression.Label(typeof(int));
            // Creating a method body.
            BlockExpression block = Expression.Block(
            // Adding a local variable.
            new[] { result },
            // Assigning a constant to a local variable: result = 1
            Expression.Assign(result, Expression.Constant(1)),
            // Adding a loop.
            Expression.Loop(
            // Adding a conditional block into the loop.
            Expression.IfThenElse(
            // Condition: value > 1
            Expression.GreaterThan(value, Expression.Constant(1)),
            // If true: result *= value --
            Expression.MultiplyAssign(result,
            Expression.PostDecrementAssign(value)),
            // If false, exit from loop and go to a label.
            Expression.Break(label, result)
            ),
            // Label to jump to.
            label
            )
            );
            // Compile an expression tree and return a delegate.
            return Expression.Lambda<Func<int, int>>(block, value).Compile();
        }
        static int CSharpFact(int value)
        {
            int result = 1;
            while (value > 1)
            {
                result *= value--;
            }
            return result;
        }
