    public string FullNumber
    {
        get
        {
            if (String.IsNullOrEmpty(DecimalPart)) {
                return IntegerPart;
            } else if (String.IsNullOrEmpty(IntegerPart)) {
                return "0." + DecimalPart;
            }
            return IntegerPart + "." + DecimalPart;
        }
        set
        {
            if (String.IsNullOrEmpty(value)) {
                IntegerPart = "";
                DecimalPart = "";
            } else if (value.Contains(".")) {
                string[] parts = value.Split('.');
                IntegerPart = parts[0];
                DecimalPart = parts[1];
            } else {
                IntegerPart = value;
                DecimalPart = "";
            }
        }
    }
    public string IntegerPart { get; set; }
    public string DecimalPart { get; set; }
