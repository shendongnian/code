    [ServiceContract(Namespace = "http://ns1.com")]
    [XmlSerializerFormat]
    public interface IOpenInvoiceInterface
    {
        [OperationContract]
        MyMethod Test(MyMethod req);
    }
    public class MyMethod
    {
        [MessageBodyMember]
        public string Param1 { get; set; }
        [MessageBodyMember(Namespace = "http://ns2.com")]
        public string Param2 { get; set; }
    }
