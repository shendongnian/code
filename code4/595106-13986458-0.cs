    namespace MyNamespace {
        [ProtoContract]
        [ProtoPartialMember(1, "Id"), ProtoPartialMember(2, "Name")]
        partial class SomeType {}
        [ProtoContract]
        [ProtoPartialMember(1, "Id"), ProtoPartialMember(2, "Date")]
        [ProtoPartialMember(3, "Value"), ProtoPartialMember(4, "Origin")]
        partial class SomeOtherType {}
    }
