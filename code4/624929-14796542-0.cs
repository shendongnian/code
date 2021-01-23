    [ProtoContract]
    public class MyClassSurrogate
    {
        [ProtoMember(1)]
        public int Number { get; set; }
        public static implicit operator MyClassSurrogate(MyClass myClass)
        {
            return 
                myClass != null 
                ? new MyClassSurrogate { Number = myClass.Number } 
                : null;
        }
        public static implicit operator MyClass(MyClassSurrogate myClass)
        {
            return new MyClass { Number = myClass.Number };
        }
    }
