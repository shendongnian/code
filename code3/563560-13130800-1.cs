        [DataContract]
        public class A
        {
            [DataMember]
            public int Prop { get; set; }
        }
            var node = ToXElement(12);
            int obj = ToObj<int>(node);
            var node2 = ToXElement(new A { Prop = 12 });
            A obj2 = ToObj<A>(node2);
