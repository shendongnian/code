    [BsonSerializer(typeof(EmailAddressSerializer))]
    public class EmailAddress
    {
        private string _value;
        public EmailAddress(string value)
        {
            _value = value;
        }
        public string Value
        {
            get { return _value; }
        }
    }
