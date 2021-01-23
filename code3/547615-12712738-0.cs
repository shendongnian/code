    public static class Car
    {
        public static readonly ReadOnlyCollection<string> carA = Array.AsReadOnly(new[]{"ford","red"});
        public static readonly ReadOnlyCollection<string> carB = Array.AsReadOnly(new[]{"bmw","black"});
        public static readonly ReadOnlyCollection<string> carC = Array.AsReadOnly(new[]{"toyota","white"});
    }
