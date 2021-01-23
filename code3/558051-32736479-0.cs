    [ProtoContract]
    public class SubClass1 : BaseClass
    {
        [ProtoMember(1)]
        public string BaseName
        {
            get{return base.Name;}
            set{base.Name = value;}
        }
        ...
        [ProtoMember(3)]
        public string Town
        {
            get; set;
        }
        [ProtoMember(4)]
        public Sex Sex
        {
            get; set;
        }
    }
