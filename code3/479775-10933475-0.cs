    [DisplayName("Previous Job No:")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "Custom Error Msg")]
    public string previousJobId { get; set; }
    private int? _previousJobId2;
    public int? previousJobId2
    {
        get
        {
            if (previousJobId == null)
            {
                return null;
            }
            else
            {
                return Int32.Parse(previousJobId);
            }
        }
        set
        {
            _previousJobId2 = value;
        }
    }
