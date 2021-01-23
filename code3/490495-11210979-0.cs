    public static void DrawCharacter(this Graphics g, char c)
    {
        byte[] src = Encoding.Unicode.GetBytes(c.ToString());
        byte[] dest = Encoding.Convert(Encoding.Unicode, Encoding.GetEncoding(437, new EncoderReplacementFallback(""), new DecoderReplacementFallback("")), src);
        if (dest.Length == 1)
        {
            DrawCharacter(g, dest[0]);
        }
    }
