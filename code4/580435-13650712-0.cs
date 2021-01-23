     [XmlRoot("Project")]
        public class RSAWrapper{
        [XmlIgnore]
        public RSAParameters RsaWrap{get;set;} 
        
        // replicate Key for Text and Cipher, subject to client's specs
        private LenghtyValue _key = null; 
        [XmlElement]
        public LenghtyValue Key{
            get{ return (_key!=null) ? _key.Value : null;}
            set{ _key = (value!=null) ? new LenghtyValue { Value = value} : null;}
        }
        // replicate Exponent for D, DP, DQ, InverseQ, Modulus, P and Q
        [XmlElement]
        public LenghtyValue Exponent{
           get{
               return new LenghtyValue { Value = ToHexFromB64(RsaWrap.Exponent);} // look up how to convert this
           }
           set {}
        } 
        public class LenghtyValue{
            [XmlText]
            public string Value{get;set;}
            [XmlAttribute("length")]
            public int Length {get{ return (""+Value").Length;} set{}}
        }
    }
   
