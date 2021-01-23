    public sealed static class Where
    {
        public bool Defense (Func<int, bool> predicate) { return predicate(); }
        public bool Dodge (Func<int, bool> predicate) { return predicate(); }
        public bool Level (Func<int, bool> predicate) { return predicate(); }
    
    }
