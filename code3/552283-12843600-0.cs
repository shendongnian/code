    public const int NumberWithMaskLength = 4;
    public string DetNumber { get; set; }
    public string NumberWithMask
    {
        get
        {
            if (!string.IsNullOrEmpty(DetNumber) && DetNumber.Length > NumberWithMaskLength)
            {
                return new string('x', DetNumber.Length - NumberWithMaskLength ) + DetNumber.Substring(DetNumber.Length - NumberWithMaskLength );
            }
            return string.Empty;
        }
    } 
