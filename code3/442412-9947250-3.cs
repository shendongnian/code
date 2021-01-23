    [ProtoContract]
    [Serializable]
    public struct Child
    {
        [ProtoMember(1)] public float X;
        [ProtoMember(2)] public float Y;
        [ProtoMember(3)] public int myField;
    }
    [ProtoContract]
    [Serializable]
    public struct Parent
    {
        [ProtoMember(1)] public int id;
        [ProtoMember(2)] public int field1;
        [ProtoMember(3)] public int field2;
        [ProtoMember(4)] public Child[] children;
    }
