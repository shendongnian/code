    public class MyRefType
    {
        public int Value { get; set; }
    }
    public void Foo() {
        MyRefType type = new MyRefType();
        AddOne(ref type);
    }
    public void AddOne(ref MyRefType type) {
        type = new MyReferenceType();
        type.Value++;
    }
