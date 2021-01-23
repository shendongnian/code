    using System;
    using System.Collections;
    class A : IEnumerable
	{
		int[] data = { 0, 1, 2, 3, 4 };
        public IEnumerator GetEnumerator()
        {
            return new AEnumerator(this);
        }
		private class AEnumerator : IEnumerator
		{
            public AEnumerator(A inst)
            {
                this.instance = inst;
            }
		    private A instance;
            private int position = -1;
            public object Current
            {
                get
                {
                    return instance.data[position];
                }
            }
            public bool MoveNext()
            {
                position++;
                return (position < instance.data.Length);
            }
            public void Reset()
            {
                position = -1;
            }
		    
		}
	}
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--- First foreach finished. ---");
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press key to exit:");
            Console.ReadKey();
        }
    }
