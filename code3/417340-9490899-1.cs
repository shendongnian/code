    using System.Xml.Serialization;
    ... 
    [XmlInclude(typeof(Response))]
    [XmlInclude(typeof(MyTable))]
    public class Response
    {
        public virtual bool Success {get;set;}
        public virtual MyTable MyTable {get;set;}
    }
