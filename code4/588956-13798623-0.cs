    using ProtoBuf;
    using ProtoBuf.Meta;
    using System;
    [ProtoContract, ProtoInclude(5, typeof(Bar))]
    public class Foo
    {
        [ProtoMember(1)]
        public int X { get; set; }
    }
    [ProtoContract]
    public class Bar : Foo
    {
        [ProtoMember(1)]
        public string Y { get; set; }
    }
    static class Program {
        static void Main() {
            var metaType = RuntimeTypeModel.Default[typeof(Bar)];
            do {
                Console.WriteLine(metaType.Type.FullName);
                foreach(var member in metaType.GetFields())
                {
                    Console.WriteLine("> {0}, {1}, field {2}",
                        member.Member.Name, member.MemberType.Name,
                        member.FieldNumber);
                }
            } while ((metaType = metaType.BaseType) != null);
        }
    }
