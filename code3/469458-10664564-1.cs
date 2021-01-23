    private string ZeroPad(ref int pNumber, ref int pLength)
    {
        string padding;
        string zeroPad;
        if ((IsNumeric(pNumber) && IsNumeric(pLength)))
        {
            padding = new string('0', pLength);
            zeroPad = (padding + pNumber.ToString());
            zeroPad = zeroPad.Substring((zeroPad.Length - pLength));
        }
        else
        {
            zeroPad = pNumber.ToString();
        }
        return zeroPad;
    }
