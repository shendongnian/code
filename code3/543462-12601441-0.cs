    using ProtoBuf;
    using System;
    [ProtoContract]
    [ProtoInclude(1, typeof(ValueImpl<int>))]
    [ProtoInclude(2, typeof(ValueImpl<float>))]
    [ProtoInclude(3, typeof(ValueImpl<double>))]
    // other types you want to support
    internal abstract class Value
    {
        public static Value Create<T>(T value) where T : IConvertible
        {
            return new ValueImpl<T> { Min = value };
        }
        public IConvertible Min { get { return MinImpl;} set { MinImpl = value;}}
        protected abstract IConvertible MinImpl {get;set;}
        [ProtoContract]
        public sealed class ValueImpl<T> : Value where T : IConvertible
        {
            [ProtoMember(1)]
            public new T Min { get; set; }
            protected override IConvertible MinImpl
            {
                get { return Min; }
                set { Min = (T)value; }
            }
        }
    }
    
    static class Program
    {
        static void Main()
        {       
            var val = Value.Create(true);
            var result = Serializer.DeepClone(val);
    
            bool x = (bool)val.Min; // true
        }
    }
