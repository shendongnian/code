    public static class States {
        static States() {
            All = Array.AsReadOnly(new string[] { "state1", "state2", "state3" });
        }
        public static readonly ReadOnlyCollection<string> All;
    }
