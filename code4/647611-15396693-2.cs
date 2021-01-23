    static void Main(string[] args) {
        //create an array of 10 million items that are randomly ordered
        var list = Enumerable.Range(1, 10000000).OrderBy(x => Guid.NewGuid()).ToList();
    
        var sw = Stopwatch.StartNew();
        var slowOrder = list.OrderBy(x => x).Skip(10).Take(10).ToList();
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
        //Took ~8 seconds on my machine
    
        sw.Restart();
        var smallVal = Quickselect(list, 11);
        var largeVal = Quickselect(list, 20);
        var elements = list.Where(el => el >= smallVal && el <= largeVal).OrderBy(el => el);
        Console.WriteLine(sw.ElapsedMilliseconds);
        //Took ~1 second on my machine
    }
    
    public static T Quickselect<T>(IList<T> list , int k) where T : IComparable {
        Random rand = new Random();
        int r = rand.Next(0, list.Count);
        T pivot = list[r];
        List<T> smaller = new List<T>();
        List<T> larger = new List<T>();
        foreach (T element in list) {
            var comparison = element.CompareTo(pivot);
            if (comparison == -1) {
                smaller.Add(element);
            }
            else if (comparison == 1) {
                larger.Add(element);
            }
        }
    
        if (k <= smaller.Count) {
            return Quickselect(smaller, k);
        }
        else if (k > list.Count - larger.Count) {
            return Quickselect(larger, k - (list.Count - larger.Count));
        }
        else {
            return pivot;
        }
    }
