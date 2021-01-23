    [IgnoreFirst(2)]
    [FixedLengthRecord(FixedMode.ExactLength)]
    public sealed class Record
    {
        [FieldTrim(TrimMode.Right)]
        [FieldFixedLength(6)]
        public String Header1;
        
        [FieldFixedLength(3)]
        public String Data1;
        [FieldInNewLine()]
        [FieldTrim(TrimMode.Right)]
        [FieldFixedLength(6)]
        public String Header2;
        [FieldFixedLength(3)]
        public String Data2;
        [FieldInNewLine()]
        [FieldTrim(TrimMode.Right)]
        [FieldFixedLength(6)]
        public String Header3;
        [FieldFixedLength(3)]
        public String Data3;
    }
