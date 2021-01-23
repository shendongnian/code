    [ProtoContract]
    public class Person
    {
        [ProtoMember(1)] public string Name { get; set; }
        [ProtoMember(2)] public int ID { get; set; }
        [ProtoMember(3)] public int Age { get; set; }
        [ProtoMember(4)] public string Email { get; set; }
    }
