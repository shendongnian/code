    [BsonDiscriminator("BaseParent")]
    public class Parent
    {
        public ObjectId Id { get; set; }
        public List<Child> Children { get; set; }
    }
    [BsonDiscriminator("BaseChild")]
    public class Child
    {
    }
    [BsonDiscriminator("Parent")]
    public class MyParent : Parent
    {
    }
    [BsonDiscriminator("Child")]
    public class MyChild : Child
    {
    }
