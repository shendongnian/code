    class LevenshteinComparer : IEqualityComparer<string>
    {
        public int MaxDistance { get; set; }
        private Levenshtein _Levenshtein = new Levenshtein();
        public LevenshteinComparer() : this(50) { }
        public LevenshteinComparer(int maxDistance)
        {
            this.MaxDistance = maxDistance;
        }
        public bool Equals(string x, string y)
        {
            int distance = _Levenshtein.iLD(x, y);
            return distance <= MaxDistance;
        }
        public int GetHashCode(string obj)
        {
            return 0; 
        }
    }
