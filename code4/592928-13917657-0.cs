    class Program
    {
        static void Main(string[] args)
        {
            // Vars
            var list = new List<List<string>>();
            var a = new List<string>();
            var b = new List<string>();
            var c = new List<string> { "one", "two", "three" };
            var d = new List<string>();
            // Add Lists
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);
            // Loop through list
            foreach (var x in list)
            {
                if (x.Count < 1)
                {
                    var tempList = new List<string>();
                    tempList.Add("some value");
                    x.Clear();
                    x.AddRange(tempList);
                }
            }
            // Print
            int count = 0;
            foreach (var l in list)
            {
                count++;
                Console.Write("(List " + count + ") ");
                foreach (var s in l)
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine("");
            }
        }
    }
