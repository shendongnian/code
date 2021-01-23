        class A : ICloneable
        {
            public object Clone()
            {
                throw new NotImplementedException();
            }
            public override string ToString()
            {
                return "Demo";
            }
        }
        class B<T> where T : A
        {
            T myT;
            
            public B(T value)
            {
                this.myT = value;
            }
            //hack the default indexer to instead allow it to be used to return N clones of myT
            public IEnumerable<T> this[int index]
            {
                get
                {
                    for (int i = 0; i < index; i++)
                    {
                        yield return (T)this.myT.Clone();
                    }
                }
            }
        }
        class Program
        {
            public static void Main(string[] args)
            {
                B<A> myB = new B<A>(new A());
                Console.WriteLine( myB[1].ToString());
                Console.ReadKey();
            }
        }
