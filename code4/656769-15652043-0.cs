    public class ValueSmsThing          // Give it a better name!
    {
        public IDontKnow Value { get; private set; }    // specify the type!
        public SmsNumber Sms   { get; private set; }    // !!
        public ValueSmsThing( IDontKnow value, SmsNumber sms) {
            Value = value;
            Sms = sms;
        }
    }
