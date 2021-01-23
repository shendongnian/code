    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;
    
    // You must apply a DataContractAttribute or SerializableAttribute 
    // to a class to have it serialized by the DataContractSerializer.
    [DataContract()]
    class Enterprise : IExtensibleDataObject
    {
    
        [DataMember(Name = "bool")]
        public bool CaptainKirk {get; set;}
    
        // more stuff here
    }
