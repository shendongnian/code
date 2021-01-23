    private string ZeroPad(int pNumber, int pLength)
    {
        string zeroPad;
        string padding = new string('0', pLength);
        zeroPad = (padding + pNumber.ToString());
        zeroPad = zeroPad.Substring(zeroPad.Length - pLength);
        return zeroPad;
    }
