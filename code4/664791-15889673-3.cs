    public static class Process<K>
    {
        public static K From<T>(Ienumerable<T> set) { ... }
    }
    ...
    string result = Process<string>.From(dataSlice);
