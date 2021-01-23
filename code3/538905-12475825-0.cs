    using ProtoBuf;
    using ProtoBuf.Meta;
    using System;
    using System.Runtime.Serialization;
    
    static class Program
    {
        public static void Main(string[] args)
        {
            // register a surrogate for Type
            RuntimeTypeModel.Default.Add(typeof(Type), false)
                                    .SetSurrogate(typeof(TypeSurrogate));
            // test it
            var clone = Serializer.DeepClone(new Foo { Type = typeof(string) });
        }
    }
    
    [ProtoContract]
    class TypeSurrogate
    {
        [ProtoMember(1)]
        public string AssemblyQualifiedName { get; set; }
        // protobuf-net wants an implicit or explicit operator between the types
        public static implicit operator Type(TypeSurrogate value)
        {
            return value==null ? null : Type.GetType(value.AssemblyQualifiedName);
        }
        public static implicit operator TypeSurrogate(Type value)
        {
            return value == null ? null : new TypeSurrogate {
                AssemblyQualifiedName  = value.AssemblyQualifiedName };
        }
    }
    
    [DataContract]
    public class Foo
    {
        [DataMember(Order=1)]
        public Type Type { get; set; }
    }
