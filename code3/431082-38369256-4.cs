    // Note that T is MyFirstEntity
    public class MyFirstEntity : SerializableEntity<MyFirstEntity>
    {
        public string SomeValue { get; set; }
    }
    // Note that T is OtherEntity
    public class OtherEntity : SerializableEntity<OtherEntity >
    {
        public int OtherValue { get; set; }
    }
