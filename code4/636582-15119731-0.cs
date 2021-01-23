    internal class ColorUseCounter
    {
        public ColorUseCounter(int ColorID, Color Color)
        {
            this.ColorID = ColorID;
            this.Color = Color;
            Count++;
        }
    
        public int ColorID { get; set; }
        public Color Color { get; set; }
        public int Count { get; set; }
    }
    
    private static Dictionary<double, ColorUseCounter> UsedColors = new Dictionary<double, ColorUseCounter>();
    private static SortedList<int, Color> AvailableColors = new SortedList<int, Color>()
    {
        { 1, Color.FromArgb(74, 117, 175) },
        { 2, Color.FromArgb(226, 134, 48) },
        { 3, Color.FromArgb(94, 158, 64) },
        { 4, Color.FromArgb(185, 58, 46) },
        ...
        ...
    };
