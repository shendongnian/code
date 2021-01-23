    public class StackOverflow_11475328
    {
        class A : IEnumerable
        {
            int[] data = { 0, 1, 2, 3, 4 };
            public IEnumerator GetEnumerator()
            {
                return new AEnumerator(this);
            }
            class AEnumerator : IEnumerator
            {
                private A parent;
                private int position = -1;
                public AEnumerator(A parent)
                {
                    this.parent = parent;
                }
                public object Current
                {
                    get { return parent.data[position]; }
                }
                public bool MoveNext()
                {
                    position++;
                    return (position < parent.data.Length);
                }
                public void Reset()
                {
                    position = -1;
                }
            }
        }
        public static void Test()
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
        }
    }
