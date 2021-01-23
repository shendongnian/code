        static void Main(string[] args)
        {
            //Lets get the 'IEnumerable Class' that RandomNum gets compiled down into.
            var IEnumeratorClass = RandomNum(10, 10);
            //All an IEnumerable is is a class with 'GetEnumerator'... so lets get it!
            var IEnumerableClass = IEnumeratorClass.GetEnumerator();
            //It can be used like so:
            while (IEnumerableClass.MoveNext())
            {
                Console.WriteLine(IEnumerableClass.Current);
            }
            Console.WriteLine(new String('-', 10));
            //Of course, that's a lot of code for a simple job.
            //Luckily - there's some nice built in functionality to make use of this.
            //This is the same as above, but much shorter
            foreach (var random in RandomNum(10, 10)) Console.WriteLine(random);
            Console.WriteLine(new String('-', 10));
            //These simple concepts are behind Unity3D coroutines, and Linq [which uses chaining extensively]
            Enumerable.Range(0, 100).Where(x => x % 2 == 0).Take(5).ToList().ForEach(Console.WriteLine);
            Console.ReadLine();
        }
        static Random rnd = new Random();
        static IEnumerable<int> RandomNum(int max, int count)
        {
            for (int i = 0; i < count; i++) yield return rnd.Next(i);
        }
        //This is an example of what the compiler generates for RandomNum, see how boring it is?
        public class RandomNumIEnumerableCompiled : IEnumerable<int>
        {
            int max, count;
            Random _rnd;
            public RandomNumIEnumerableCompiled(int max, int count)
            {
                this.max = max;
                this.count = count;
                _rnd = rnd;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return new RandomNumIEnumeratorCompiled(max, count, rnd);
            }
            IEnumerator<int> IEnumerable<int>.GetEnumerator()
            {
                return new RandomNumIEnumeratorCompiled(max, count, rnd);
            }
        }
        public class RandomNumIEnumeratorCompiled : IEnumerator<int>
        {
            int max, count;
            Random _rnd;
            int current;
            int currentCount = 0;
            public RandomNumIEnumeratorCompiled(int max, int count, Random rnd)
            {
                this.max = max;
                this.count = count;
                _rnd = rnd;
            }
            int IEnumerator<int>.Current { get { return current; } }
            object IEnumerator.Current { get { return current; } }
            public bool MoveNext()
            {
                if (currentCount < count)
                {
                    currentCount++;
                    current = rnd.Next(max);
                    return true;
                }
                return false;
            }
            public void Reset() { currentCount = 0; }
            public void Dispose() { }
        }
