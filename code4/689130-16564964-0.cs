    [ProtoContract]
    class DecimalWrapper {
        [ProtoMember(1)]
        public decimal Value { get; set; }
    }
    [ProtoContract]
    class MyDecimalWrapper {
        [ProtoMember(1)]
        public MyDecimal Value { get; set; }
    }
