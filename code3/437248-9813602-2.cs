    class RecordType
    {
        //constructor to set the properties omitted
        public byte Address { get; private set; }
        public byte OldValue { get; private set; }
        public byte NewValue { get; private set; }
    }
    IEnumerable<RecordType> Transform(List<byte> bytes)
    {
        //validation that bytes.Count is divisible by 3 omitted
        for (int index = 0; index < bytes.Count; index += 3)
            yield return new RecordType(bytes[index], bytes[index + 1], bytes[index + 2]);
    }
