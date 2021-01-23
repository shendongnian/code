    using System;
    using System.Collections.Generic;
    
    namespace MemoryEfficientFoo
    {
        class Foo // This is our data structure 
        {
            public int A;
            public string B;
            public Decimal C;
        }
    
        /// <summary>
        /// List which does store Foos with much less memory if many values are equal. You can cut memory consumption by factor 3 or if all values 
        /// are different you consume 5 times as much memory as if you would store them in a plain list! So beware that this trick
        /// might not help in your case. Only if many values are repeated it will save memory.
        /// </summary>
        class FooList : IEnumerable<Foo> 
        {
            Dictionary<int, string> Index2B = new Dictionary<int, string>();
            Dictionary<string, int> B2Index = new Dictionary<string, int>();
    
            Dictionary<int, Decimal> Index2C = new Dictionary<int, decimal>();
            Dictionary<Decimal,int> C2Index = new Dictionary<decimal,int>();
    
            struct FooIndex
            {
                public int A;
                public int BIndex;
                public int CIndex;
            }
    
            // List of foos which do contain only the index values to the dictionaries to lookup the data later.
            List<FooIndex> FooValues = new List<FooIndex>();
    
            public void Add(Foo foo)
            {
                int bIndex;
                if(!B2Index.TryGetValue(foo.B, out bIndex))
                {
                    bIndex = B2Index.Count;
                    B2Index[foo.B] = bIndex;
                    Index2B[bIndex] = foo.B;
                }
    
                int cIndex;
                if (!C2Index.TryGetValue(foo.C, out cIndex))
                {
                    cIndex = C2Index.Count;
                    C2Index[foo.C] = cIndex;
                    Index2C[cIndex] = cIndex;
                }
    
                FooIndex idx = new FooIndex
                {
                    A = foo.A,
                    BIndex = bIndex,
                    CIndex = cIndex
                };
    
                FooValues.Add(idx);
            }
    
            public Foo GetAt(int pos)
            {
                var idx = FooValues[pos];
                return new Foo
                {
                    A = idx.A,
                    B = Index2B[idx.BIndex],
                    C = Index2C[idx.CIndex]
                };
            }
    
            public IEnumerator<Foo> GetEnumerator()
            {
                for (int i = 0; i < FooValues.Count; i++)
                {
                    yield return GetAt(i);
                }
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                FooList list = new FooList();
                List<Foo> fooList = new List<Foo>();
                long before = GC.GetTotalMemory(true);
                for (int i = 0; i < 1000 * 1000; i++)
                {
                    list
                    //fooList
                        .Add(new Foo
                        {
                            A = i,
                            B = "Hi",
                            C = i
                        });
    
                }
                long after = GC.GetTotalMemory(true);
                Console.WriteLine("Did consume {0:N0}bytes", after - before);
            }
        }
    }
