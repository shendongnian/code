     [XmlAttribute] public Single FloatValue { get; set; }
        public bool ShouldSerializeFloatValue()
        {
           if (FloatValue == 0.0)
             return false;
           return true;
        }     
    
        [XmlAttribute] public Int32 IntValue { get; set; }
        public bool ShouldSerializeIntValue()
        {
          if (IntValue <= 0)
            return false;
          return true;
        }
    }
