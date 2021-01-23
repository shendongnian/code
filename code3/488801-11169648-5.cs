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
            public Speech()
            {
                this.Items = new List<LanguageItem>();
            }
    
            [XmlArray]
            public List<LanguageItem> Items;
        }
    
        [Serializable]
        public class LanguageItem
        {
            [XmlAttribute]
            public string Language { get; set; }
    
            [XmlAttribute]
            public int Id { get; set; }
        }
    }
