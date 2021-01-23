    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace StackOverflowSamples
    {
        [Serializable]
        public class Speech
        {
            [XmlAttribute]
            public string Language { get; set; }
    
            [XmlAttribute]
            public int Id { get; set; }
        }
    }
