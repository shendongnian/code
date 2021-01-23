    public static byte[] GetBytes(string value)
    {
        return Array.ConvertAll(value.Split('-'), s => byte.Parse(s, System.Globalization.NumberStyles.HexNumber));
    }
    ...
    var originalBytes = new byte[] { 1, 2, 3, 4, 5 };
    var stValue = BitConverter.ToString(originalBytes); // "01-02-03-04-05"
    var bytes = GetBytes(stValue); // [ 1, 2, 3, 4, 5 ]
