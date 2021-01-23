    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    [Serializable()]
    public class MyClass
    {
        private list<blocks> m_Blocks = new List<block>();
        [XMLArray("Items")]
        public list<block> Blocks{ 
            get{ return m_blocks; }
            set{ m_Blocks = value; }
        };
        // ... other members
    }
