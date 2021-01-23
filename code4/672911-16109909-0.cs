        [DataContract]
        public class DerivedType : BaseType
        {
            [DataMember(Order = 0)]
            public string bird;
            [DataMember(Order = 1)]
            public string parrot;
        }
