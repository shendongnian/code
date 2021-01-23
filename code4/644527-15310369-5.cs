        [DataContract(Name="Foo")]
        public class FooA
        {
            [DataMember] 
            public int Value;
        }
        [DataContract(Name = "Foo")]
        public class FooB
        {
            [DataMember]
            public int Value;
        }
        static public void Main()
        {
            var fooA = new FooA() {Value = 42};
            var serialised = Serialize(fooA);
            // Cross domain
            var fooB = (FooB) Deserialize(serialised, typeof(FooB));
            Console.WriteLine(fooB.Value);
        }
