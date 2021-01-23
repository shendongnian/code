    class Program
    {
        static int samplesize = 1000000;
        //ensure these are big enough that we don't spend time allocating new buffers while the stopwatch is running
        static Dictionary<int, string> ints = new Dictionary<int,string>(samplesize * 4); 
        static Dictionary<double,string> doubles = new Dictionary<double,string>(samplesize * 4);
        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, samplesize).ToArray() ;
            var clock = new Stopwatch();
            test1(items); //jit hit, discard first run. Also ensure all keys already exist in the dictionary for both tests
            clock.Restart();
            test1(items);
            clock.Stop();
            Console.WriteLine("Time for naive unsorted: " + clock.ElapsedTicks.ToString());
            test2(items); //jit hit
            clock.Restart();
            test2(items);
            clock.Stop();
            Console.WriteLine("Time for separated/branch prediction friendly: " + clock.ElapsedTicks.ToString());
            Console.ReadKey(true);
        }
        static void test1(IEnumerable<int> items)
        {
            foreach(int item in items)
            {
                //different code branches that still do significant work in the cpu
                // doing more work here results in a larger branch-prediction win, to a point
                if (item % 3 == 0)
                {   //force hash computation and multiplication op (both cpu-bound)
                    ints[item] = (item * 2).ToString();
                }
                else
                {
                    doubles[(double)item] = (item * 3).ToString();
                }
            }
        }
        static void test2(IEnumerable<int> items)
        {
            //doing MORE work: need to evaluate our items two ways
            var intItems = items.Where(i => i % 3 == 0).ToArray();
            var doubleItems = items.Where(i => i % 3 != 0).ToArray();
            // but now there is no branching... adding all the ints, then adding all the doubles.
            foreach (var item in intItems) { ints[item] = (item * 2).ToString(); }
            foreach (var item in doubleItems) { doubles[(double)item] = (item * 3).ToString(); }
        }
    }
