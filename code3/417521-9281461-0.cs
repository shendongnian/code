    using System.Xml.Serialization;
    using System.Xml.Schema;
    using System;
    
    [SerializableAttribute()]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class message
    {
        [XmlElementAttribute("envelope", Form = XmlSchemaForm.Unqualified)]
        public messageEnvelope[] envelope { get; set; }
    
        [XmlArrayAttribute(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItemAttribute("action", typeof(messageStatusAction), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public messageStatusAction[][] status { get; set; }
    
        [XmlElementAttribute("host", Form = XmlSchemaForm.Unqualified)]
        public messageHost[] host { get; set; }
    
        [XmlAttributeAttribute()]
        public string uuid { get; set; }
    }
    
    [SerializableAttribute()]
    public partial class messageEnvelope
    {
        [XmlArrayAttribute(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItemAttribute("monitor", typeof(messageEnvelopeFromMonitor), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public messageEnvelopeFromMonitor[][] from { get; set; }
    
        [XmlArrayAttribute(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItemAttribute("account", typeof(messageEnvelopeTOAccountFactory[]), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        [XmlArrayItemAttribute("factory", typeof(messageEnvelopeTOAccountFactory), Form = XmlSchemaForm.Unqualified, IsNullable = false, NestingLevel = 1)]
        public messageEnvelopeTOAccountFactory[][][] to { get; set; }
    
        [XmlAttributeAttribute()]
        public string received { get; set; }
    
        [XmlAttributeAttribute()]
        public string subject { get; set; }
    }
    
    [SerializableAttribute()]
    public partial class messageEnvelopeFromMonitor
    {
        [XmlAttributeAttribute()]
        public string name { get; set; }
    
        [XmlAttributeAttribute()]
        public string user_description { get; set; }
    
        [XmlAttributeAttribute()]
        public string uuid { get; set; }
    }
    
    [SerializableAttribute()]
    public partial class messageEnvelopeTOAccountFactory
    {
        [XmlAttributeAttribute()]
        public string name { get; set; }
    }
    
    [SerializableAttribute()]
    public partial class messageStatusAction
    {
        [XmlElementAttribute("session", Form = XmlSchemaForm.Unqualified)]
        public messageStatusActionSession[] session { get; set; }
    
        [XmlAttributeAttribute()]
        public string name { get; set; }
    
        [XmlAttributeAttribute()]
        public string occured { get; set; }
    
        [XmlAttributeAttribute()]
        public string type { get; set; }
    }
    
    [SerializableAttribute()]
    public partial class messageStatusActionSession
    {
        [XmlAttributeAttribute()]
        public string completed { get; set; }
    
        [XmlAttributeAttribute()]
        public string name { get; set; }
    
        [XmlAttributeAttribute()]
        public string started { get; set; }
    
        [XmlAttributeAttribute()]
        public string current { get; set; }
    
        [XmlAttributeAttribute()]
        public string total { get; set; }
    
        [XmlAttributeAttribute()]
        public string unit { get; set; }
    }
    
    [SerializableAttribute()]
    public partial class messageHost
    {
        [XmlAttributeAttribute()]
        public string name { get; set; }
    }
    
    [SerializableAttribute()]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class NewDataSet
    {
        [XmlElementAttribute("message")]
        public message[] Items { get; set; }
    }
