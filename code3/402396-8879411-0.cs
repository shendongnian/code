    [YAXSerializableType(FieldsToSerialize=YAXSerializationFields.AttributedFieldsOnly)]
    public sealed class Broker
    {
        [YAXSerializableField]
        public  int Id { get; private set; }
        [YAXSerializableField]
        public  string Name { get; private set; }
        // or equaly give attribute to a private field
        [YAXSerializableField]
        private string _hosts;
        // and leave the property un-attributed
        public string Hosts { get { return _hosts; } }
    }
