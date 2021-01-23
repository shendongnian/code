    class EqCmp : IEqualityComparer<string> {
        public bool Equals(string x, string y) {
            return GetKey(x).SequenceEqual(GetKey(y));
        }
        public int GetHashCode(string obj) {
            // Using Sum could cause OverflowException.
            return GetKey(obj).Aggregate(0, (sum, subkey) => sum + subkey.GetHashCode());
        }
        static IEnumerable<string> GetKey(string line) {
            // If we just split to 3 strings, the last one could exceed the key, so we split to 4.
            // This is not the most efficient way, but is simple.
            return line.Split(new[] { '*' }, 4).Take(3);
        }
    }
    class Program {
        static void Main(string[] args) {
            var l1 = new List<string> {
                "index1*index1*index1*some text",
                "index1*index1*index2*some text ** test test test",
                "index1*index2*index1*some text",
                "index1*index2*index2*some text",
                "index2*index1*index1*some text"
            };
            var l2 = new List<string> {
                "index1*index1*index2*some text ** test test test",
                "index2*index1*index1*some text",
                "index2*index1*index2*some text"
            };
            var eq = new EqCmp();
            Console.WriteLine("Elements that are both in l1 and l2:");
            foreach (var line in l1.Intersect(l2, eq))
                Console.WriteLine(line);
            Console.WriteLine("\nElements that are in l1 but not in l2:");
            foreach (var line in l1.Except(l2, eq))
                Console.WriteLine(line);
            // Etc...
        }
    }
