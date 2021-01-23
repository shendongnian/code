    [IgnoreEmptyLines()]
    [DelimitedRecord(";")]
    public sealed class SemicolonsRow
    {
        [FieldQuoted('"', QuoteMode.OptionalForRead, MultilineMode.AllowForRead)]
        public String LastName;
    
        [FieldOptional()]
        [FieldQuoted('"', QuoteMode.OptionalForRead, MultilineMode.AllowForRead)]
        public String Name;
    
        [FieldOptional()]
        [FieldQuoted('"', QuoteMode.OptionalForRead, MultilineMode.AllowForRead)]
        public String MidName;
    
        [FieldOptional()]
        [FieldQuoted('"', QuoteMode.OptionalForRead, MultilineMode.AllowForRead)]
        public String BirthDate;
    
        [FieldOptional()]
        [FieldQuoted('"', QuoteMode.OptionalForRead, MultilineMode.AllowForRead)]
        private String DummyField1;
        [FieldOptional()]
        [FieldQuoted('"', QuoteMode.OptionalForRead, MultilineMode.AllowForRead)]
        private String DummyField2;
        [FieldOptional()]
        [FieldQuoted('"', QuoteMode.OptionalForRead, MultilineMode.AllowForRead)]
        private String DummyField3;
        [FieldOptional()]
        [FieldQuoted('"', QuoteMode.OptionalForRead, MultilineMode.AllowForRead)]
        private String DummyField4;
        [FieldOptional()]
        [FieldQuoted('"', QuoteMode.OptionalForRead, MultilineMode.AllowForRead)]
        private String DummyField5;
    }
