    namespace ConsoleApplication1 {
    unsafe class Program : ILNumerics.ILMath {
    static void Main(string[] args) {
        int numItems = 0, repet = 20000; 
        Stopwatch sw01 = new Stopwatch();
        // results are collected in a dictionary: 
        // key: list length
        // value: tuple with times taken by ILNumerics and List.Sort()
        var results = new Dictionary<int, Tuple<float,float>>();
        // the comparer used for List.Sort() see below 
        ItemComparer comparer = new ItemComparer();
        // run test for copy-sort-copy back via ILNumerics
        for (numItems = 500; numItems < 50000; numItems = (int)(numItems * 1.3)) {
            Console.Write("\r measuring: {0}", numItems);  
            long ms = 0;
            List<Item> a = makeData(numItems);
            for (int i = 0; i < repet; i++) {
                sw01.Restart();
                List<Item> b1 = fastSort(a);
                sw01.Stop();
                ms += sw01.ElapsedMilliseconds;
            }
            results.Add(numItems,new Tuple<float,float>((float)ms / repet, 0f)); 
        }
        // run test using the straightforward approach, List.Sort(IComparer)
        for (numItems = 500; numItems < 50000; numItems = (int)(numItems * 1.3)) {
            Console.Write("\r measuring: {0}", numItems);  
            List<Item> a = makeData(numItems);
            long ms = 0;
            for (int i = 0; i < repet; i++) {
                List<Item> copyList = new List<Item>(a);
                sw01.Restart();
                copyList.Sort(comparer);
                sw01.Stop();
                ms += sw01.ElapsedMilliseconds;
            }
            results[numItems] = new Tuple<float, float>(results[numItems].Item1, (float)ms / repet); 
        }
        // Print results
        Console.Clear(); 
        foreach (var v in results) 
            Console.WriteLine("Length: {0} | ILNumerics/CLR: {1} / {2} ms", v.Key, v.Value.Item1, v.Value.Item2);
        Console.ReadKey(); 
    }
    public class Item {
        public double Value;
        //... some else data fields
    }
    public class ItemComparer : Comparer<Item> {
        public override int Compare(Item x, Item y) {
            return (x.Value > y.Value)  ? 1 
                 : (x.Value == y.Value) ? 0 : -1;
        }
    }
    public static List<Item> makeData(int n) {
        List<Item> ret = new List<Item>(n); 
        using (ILScope.Enter()) {
            ILArray<double> A = rand(1,n);
            double[] values = A.GetArrayForRead(); 
            for (int i = 0; i < n; i++) {
                ret.Add(new Item() { Value = values[i] }); 
            }
        }
        return ret; 
    }
    
    public static List<Item> fastSort(List<Item> unsorted) {
        //double [] values = unsorted.ConvertAll<double>(item => item.Value).ToArray(); 
        
        //// maybe more efficient? safes O(n) run 
        //double[] values = new double[unsorted.Count];
        //for (int i = 0; i < values.Length; i++) {
        //    values[i] = unsorted[i].Value;
        //}
        using (ILScope.Enter()) {
            // convert incoming
            ILArray<double> doubles = zeros(unsorted.Count);
            double[] doublesArr = doubles.GetArrayForWrite();
            for (int i = 0; i < doubles.Length; i++) {
                doublesArr[i] = unsorted[i].Value;
            }
            // do fast sort 
            ILArray<double> indices = empty();
            doubles = sort(doubles, Indices: indices);
            // convert outgoing
            List<Item> ret = new List<Item>(unsorted.Count); 
            foreach (double i in indices) ret.Add(unsorted[(int)i]); 
            return ret; 
        }
    }
    }
    }
