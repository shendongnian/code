    [ProtoContract]
    public class MyRoot {
        [ProtoMember(1, DynamicType=true)]
        public object Value { get; set; }
    }
