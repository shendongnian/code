    public class Func
    {
        public readonly MethodInfo Method;
        public readonly object Target;
        #region Ctors
        public static Func Get<TResult>(Func<TResult> func)
        {
            return new Func(func.Method, func.Target);
        }
        public static Func Get<T, TResult>(Func<T, TResult> func)
        {
            return new Func(func.Method, func.Target);
        }
        public static Func Get<T1, T2, TResult>(Func<T1, T2, TResult> func)
        {
            return new Func(func.Method, func.Target);
        }
        public static Func Get<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
        {
            return new Func(func.Method, func.Target);
        }
        #endregion
        private Func(MethodInfo method, object target)
        {
            this.Method = method;
            this.Target = target;
        }
        public object Run(params object[] parameters)
        {
            return this.Method.Invoke(this.Target, parameters);
        }
    }
    public class MyClass
    {
        public string Data { get; set; }
        public int Add(int x, int y)
        {
            return x + y;
        }
        public bool IsZero(int i)
        {
            return i == 0;
        }
        public void Print(object msg)
        {
            Console.WriteLine(msg);
        }
        public bool ValidateData()
        {
            return string.IsNullOrEmpty(this.Data);
        }
        public void TestMethods()
        {
            var tests = new Dictionary<Func, object[][]>
                            {
                                {
                                    Func.Get<int, int, int>(this.Add),
                                    new[]
                                        {
                                            new object[] {2, 3},
                                            new object[] {5, 0},
                                            new object[] {10, -2}
                                        }
                                    },
                                {
                                    Func.Get<int, bool>(this.IsZero),
                                    new[]
                                        {
                                            new object[] {1},
                                            new object[] {0},
                                            new object[] {-1}
                                        }
                                    },
                                {
                                    Func.Get<object, VoidReturn>(o =>
                                                                     {
                                                                         this.Print(o);
                                                                         return VoidReturn.Blank;
                                                                     }),
                                    new[]
                                        {
                                            new object[] {"Msg1"},
                                            new object[] {"Msg2"},
                                            new object[] {"Msg3"}
                                        }
                                    },
                                {Func.Get(this.ValidateData), null}
                            };
            foreach (var testFunc in tests)
            {
                Console.WriteLine("Testing method: " + testFunc.Key.Method.Name);
                Console.WriteLine();
                foreach (var parameters in testFunc.Value)
                {
                    Console.WriteLine("Parameters: " + string.Join(", ", parameters));
                    
                    var result = testFunc.Key.Run(parameters);
                    Console.WriteLine(result is VoidReturn ? "*void" : ("Returned: " + result));
                    Console.WriteLine();
                }
                Console.WriteLine("________________________________");
                Console.WriteLine();
            }
        }
        private enum VoidReturn
        {
            Blank
        }
    }
