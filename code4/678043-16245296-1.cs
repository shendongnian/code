    using ProtoBuf;
    using ProtoBuf.Meta;
    using System;
    public class A
    {
        // we'll use this to detect how it was constructed
        public bool ViaOperator { get; set; }
        public int X { get; set; }
    }
    public class B : A
    {
        public int Y { get; set; }
    }
    public class C : B
    {
        public int Z { get; set; }
    }
    
    
    [ProtoContract, ProtoInclude(1, typeof(BSer))]
    public class ASer
    {
        [ProtoMember(2)] public int X { get; set; }
    
        protected virtual A ToA()
        {
            return new A { X = X };
        }
    
        public static implicit operator A(ASer value)
        {
            if (value == null) return null;
            var a = value.ToA();
            a.ViaOperator = true;
            return a;
        }
        public static implicit operator ASer(A value)
        {
            if (value == null) return null;
            var c = value as C;
            if(c != null) return new CSer {
                X = c.X, Y = c.Y, Z = c.Z};
            var b = value as B;
            if(b != null) return new BSer {
                X = b.X, Y = b.Y };
            return new ASer { X = value.X };
        }
    }
    [ProtoContract, ProtoInclude(1, typeof(CSer))]
    public class BSer : ASer
    {
        [ProtoMember(2)] public int Y { get; set; }
    
        protected override A ToA()
        {
            return new B { X = X, Y = Y };
        }
    }
    [ProtoContract]
    public class CSer : BSer
    {
        [ProtoMember(2)] public int Z { get; set; }
    
        protected override A ToA()
        {
            return new C { X = X, Y = Y, Z = Z };
        }
    }
    
    static class Program
    {
        static void Main()
        {
            var model = TypeModel.Create();
            model.Add(typeof(A), false).AddSubType(2, typeof(B)).SetSurrogate(typeof(ASer));
            model[typeof(B)].AddSubType(2, typeof(C));
    
            A obj = new B { X = 1, Y = 2 };
    
            var clone = (B)model.DeepClone(obj);
            Console.WriteLine("{0}, {1}, {2}", clone.X, clone.Y, clone.ViaOperator);
    
        }
    }
