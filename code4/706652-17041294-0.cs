    [DataContract(IsReference = true)]
    [KnownType(typeof(Tablo7))]
    [KnownType(typeof(Tablo8))]
    public class Tablo5 { 
      //common class
    }
    [DataContract]
    public class Tablo7 : Tablo5{
        [DataMember]
        public Double MyProp {get;set;}
    }
    [DataContract]
    public class Tablo8 : Tablo5{
        [DataMember]
        public Int32 MySecondProp {get;set;}
    }
