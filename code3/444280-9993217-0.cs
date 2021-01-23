    private static readonly Bitmap BMP = new Bitmap(1000, 1000);
    private static readonly Graphics GRAPHICS = Graphics.FromImage(BMP);
    private static readonly Font FONT = new Font("Arial", 20);
    private static readonly RectangleF RECT = new RectangleF(0, 0, 1000, 1000);
    public static bool CheckInvisibleChars(string text)
    {
        var stringFormat1 = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
        stringFormat1.SetMeasurableCharacterRanges(
            Enumerable.Range(0, text.Length - 2).Select(i => new CharacterRange(i, 1)).ToArray());
        return GRAPHICS.MeasureCharacterRanges(text, FONT, RECT, stringFormat1).Any(
            reg => reg.GetBounds(GRAPHICS).Width.Equals(0f));
    }
