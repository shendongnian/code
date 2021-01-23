    [IgnoreFirst(1)]
    [IgnoreEmptyLines()]
    [DelimitedRecord(",")]
    public class Job
    {
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string WM_Identifier;
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string JobDesription;
    
        public string Job_Start_Date_Time;
        public string Job_End_Date_Time;
    }
