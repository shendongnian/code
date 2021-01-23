    using System.Xml.Serialization
    
    [XmlType(Namespace = "http://tempuri.org/", TypeName = "SomethingOtherThanMailMessage")]
    public class MailMessage : System.Net.Mail.MailMessage
    {
    }
