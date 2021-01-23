    using System.Drawing;
    using System.Security.Cryptography;
    protected Color GetColor()
    {
        KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        return Color.FromKnownColor(colors[GetRand(colors.Length)]);
    }
    protected int GetRand(int maxValue)
    {
        RandomNumberGenerator rng = RNGCryptoServiceProvider.Create();
        byte[] bytes = new byte[4];
        rng.GetBytes(bytes);
        int ranNum = BitConverter.ToInt32(bytes, 0);
        return Math.Abs(ranNum % maxValue);
    }
