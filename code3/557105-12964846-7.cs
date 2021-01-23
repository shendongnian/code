    [MessageContract(IsWrapped = false)]
    public class MyInt
    {
        [MessageBodyMember]
        public int Result { get; set; }
        public static implicit operator MyInt(int i)
        {
            return new MyInt { Result = i };
        }
        public static implicit operator int(MyInt m)
        {
            return m.Result;
        }
    }
