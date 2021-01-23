    [DataContract] // Probably unnecessary to specify this
    public abstract class AbstractTest
    {
        [DataMember] // Again, probably unnecessary.
        public abstract string SayHello { get; set; }
    }
    [DataContract]
    public class Test : AbstractTest
    {
        [DataMember]
        public string Month { get { return "June"; } set { } }
        [DataMember] // You must specify, that in this class, this property is a data member of the contract--this is not "inherited" from the base class.
        public override string SayHello { get { return "HELLO"; } set { } }
    }
