     [Flags]
        public enum RGB
        {
            R,
            G,
            B
        }
...
    public List<RGB> l = new List<RGB>();
    l.Add(RGB.r | RGB.G)
