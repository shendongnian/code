    [CollectionDataContract]
    [KnownTypes(typeof(TestGroup))] // Need to tell DCS that this class's metadata will be included with members from this abstract base class.
    public abstract class AbstractTestGroup : ObservableCollection<AbstractTest>
    {
        [DataMember]
        public abstract string Name { get; set; }
    }
    [CollectionDataContract]
    //[KnownTypes(typeof(Test))] -- You don't need this here....
    public class TestGroup : AbstractTestGroup
    {
        public override string Name
        {
            get { return "TestGroupName"; }
            set { }
        }
        [DataMember]
        public string Why { get { return "Why"; } set { } }
    }
    [DataContract]
    [KnownTypes(typeof(Test))] // Again, you need to inform DCS
    public abstract class AbstractTest
    {
        [DataMember]
        public abstract string SayHello { get; set; }
    }
    [DataContract]
    public class Test : AbstractTest
    {
        //Concrete class - members in this class get serialized
        [DataMember]
        public string Month { get { return "June"; } set { } }
        public override string SayHello { get { return "HELLO"; } set { } }
    }
