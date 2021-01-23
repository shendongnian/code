    private class IndexBased : ITester {
        private readonly bool[] map = new bool[128];
        public IndexBased() {
            foreach (var ch in "bcdfghjklmnpqrstvwxz") {
                map[ch] = map[Char.ToUpper(ch)] = true;
            }
        }
        public bool IsConsonant(Char ch) {
            return ch < map.Length && map[ch];
        }
    }
