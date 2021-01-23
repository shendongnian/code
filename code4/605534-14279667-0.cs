    [ProtoContract]
    public class NewClass
    {
        [ProtoMember(2)]
        public string Prop1 { get; set; 
        [ProtoMember(100)]
        public string Prop2 { get; set; }
    
        [ProtoMember(1)] // this 1 is from ProtoMember
        private Shim ShimForSerialization { get { return new Shim(this); } }
    
        // this disables the shim during serialiation; only Prop1 and Prop2 will
        // be written
        public bool ShouldSerializeShimForSerialization() { return false; }
    
        [ProtoContract]
        private class Shim {
            private readonly NewClass parent;
            public Shim(NewClass parent) {
                this.parent = parent;
            }
            [ProtoMember(1)]
            public string Prop1 {
                get { return parent.Prop1;}
                set { parent.Prop1 = value;}
            }
    
        }
    }
