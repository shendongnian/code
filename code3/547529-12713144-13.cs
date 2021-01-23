    public enum RgbColor : byte
    {
        Black,
        Red,
        Green,
        Blue,
        White,
        Default
    }
    
    static void Main(string[] args)
    {
        Dictionary<RgbColor, Int32> ColorRGB = new Dictionary<RgbColor, int>();
        ColorRGB.Add(RgbColor.Black, 0x000000);
        ColorRGB.Add(RgbColor.Default, 0x0000ff);
        ColorRGB.Add(RgbColor.Blue, 0x0000ff);
        ColorRGB.Add(RgbColor.Green, 0x00ff00);
        ColorRGB.Add(RgbColor.White, 0xffffff);
    
        Debug.WriteLine(ColorRGB[RgbColor.Blue].ToString("X6"));
        Debug.WriteLine(ColorRGB[RgbColor.Default].ToString("X6"));
        Debug.WriteLine(ColorRGB[RgbColor.Black].ToString("X6"));
        Debug.WriteLine(ColorRGB[RgbColor.White].ToString("X6"));
