    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    namespace SameValueCodeContracts
    {
        [ContractClass(typeof(RuntimePropertyContracts))]
        interface IRuntimeProperty
        {
            int AlwaysTheSame { get; }
        }
        internal static class RuntimePropertyExtensions
        {
            private static Dictionary<IRuntimeProperty, int> cache = new Dictionary<IRuntimeProperty, int>();
            internal static bool IsAlwaysTheSame(this IRuntimeProperty runtime, int newValue)
            {
                Console.WriteLine("in IsAlwaysTheSame for {0} with {1}", runtime, newValue);
                if (cache.ContainsKey(runtime))
                {
                    bool result = cache[runtime] == newValue;
                    if (!result)
                    {
                        Console.WriteLine("*** expected {0} but got {1}", cache[runtime], newValue);
                    }
                    return result;
                }
                else
                {
                    cache[runtime] = newValue;
                    Console.WriteLine("cache now contains {0}", cache.Count);
                    return true;
                }
            }
        }
        [ContractClassFor(typeof(IRuntimeProperty))]
        internal class RuntimePropertyContracts : IRuntimeProperty
        {
            public int AlwaysTheSame
            {
                get
                {
                    Contract.Ensures(this.IsAlwaysTheSame(Contract.Result<int>()));
                    return default(int);
                }
            }
        }
        internal class GoodObject : IRuntimeProperty
        {
            private readonly string name;
            private readonly int myConstantValue = (int)DateTime.Now.Ticks;
            public GoodObject(string name)
            {
                this.name = name;
                Console.WriteLine("{0} initialised with {1}", name, myConstantValue);
            }
            public int AlwaysTheSame
            {
                get
                {
                    Console.WriteLine("{0} returning {1}", name, myConstantValue);
                    return myConstantValue;
                }
            }
        }
        internal class BadObject : IRuntimeProperty
        {
            private readonly string name;
            private int myVaryingValue;
            public BadObject(string name)
            {
                this.name = name;
                Console.WriteLine("{0} initialised with {1}", name, myVaryingValue);
            }
            public int AlwaysTheSame
            {
                get
                {
                    Console.WriteLine("{0} returning {1}", name, myVaryingValue);
                    return myVaryingValue++;
                }
            }
        }
        internal class Program
        {
            private static void Main(string[] args)
            {
                int value;
                GoodObject good1 = new GoodObject("good1");
                value = good1.AlwaysTheSame;
                value = good1.AlwaysTheSame;
                Console.WriteLine();
                GoodObject good2 = new GoodObject("good2");
                value = good2.AlwaysTheSame;
                value = good2.AlwaysTheSame;
                Console.WriteLine();
                BadObject bad1 = new BadObject("bad1");
                value = bad1.AlwaysTheSame;
                Console.WriteLine();
                BadObject bad2 = new BadObject("bad2");
                value = bad2.AlwaysTheSame;
                Console.WriteLine();
                try
                {
                    value = bad1.AlwaysTheSame;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Last call caused an exception: {0}", e.Message);
                }
            }
        }
    }
