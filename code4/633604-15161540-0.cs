    public class C
    {
        public ObjectId Id { get; set; }
        public A List { get; set; }
    }
    public class A : List<B>
    {
    }
