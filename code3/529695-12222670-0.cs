    using System;
    using System.Runtime.Serialization;
    namespace SerializationExample
    {
        [Serializable]
        public class Model
        {
            public Model(){
                A = new SomeClass();
            }
            [OptionalField]
            public int value;
            [OptionalField]
            public SomeClass A;
            [OptionalField]
            public AnotherClass B;
            [OnDeserializing]
            void OnDeserializing(StreamingContext context)
            {
                B = new AnotherClass("Set during deserializing");
            }
            [OnDeserialized]
            void OnDeserialized(StreamingContext context)
            {
                // Do sth. here after the object has been deserialized
            }
            public override string ToString()
            {
                return String.Format("A: {0}\nB: {1}", A, B);
            }
        }
        [Serializable]
        public class SomeClass
        {
            public string Value { get; set; }
            public SomeClass()
            {
                Value = "Default";
            }
            public override string ToString()
            {
                return Value;
            }
        }
        [Serializable]
        public class AnotherClass
        {
            public string Value { get; private set; }
            public AnotherClass(string v)
            {
                Value = v;
            }
            public override string ToString()
            {
                return Value;
            }
        }
    }
