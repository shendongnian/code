        public static void Main(string[] args)
        {
            var xs = new[] { 1, 5, 9 };
            var ys = new[] { 2, 7, 8 };
            var zs = new[] { 0, 3, 4, 6 };
            foreach (var a in new [] { xs, ys, zs }.Merge())
                Console.WriteLine(a);
        }
