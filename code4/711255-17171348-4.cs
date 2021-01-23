    public enum CODES
    {
        [Description("11")]
        Success,
        [Description("22")]
        Warning,
        [Description("33")]
        Error
    }
    // to enum
    String response = "22";
    CODES responseAsEnum = response.ToEnum<CODES>(); // CODES.Warning
    // from enum
    CODES status = CODES.Success;
    String statusAsString = status.ToDescription(); // "11"
