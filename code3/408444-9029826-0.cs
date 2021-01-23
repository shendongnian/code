    public static class MyRandom {
        static Random random = new Random();
        static readonly object sync = new object();
        public static void Seed(int seed) {
            lock(sync) { random = new Random(seed); }
        }
        public static int Next() {
            lock(sync) { return random.Next(); }
        }
        public static int Next(int max) {
            lock(sync) { return random.Next(max); }
        } 
        ...
    }
