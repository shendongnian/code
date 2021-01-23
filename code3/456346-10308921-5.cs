    public class MyRefType
    {
        public int Value { get; set; }
    }
    public void Foo() {
        MyRefType type = new MyRefType();
        AddOne(type);
    }
    public void AddOne(MyRefType type) {
        type = new MyReferenceType();
        type.Value++;
    }
