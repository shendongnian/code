    public class A
    {
        [MyAttribute1]
        public string field;
    }
    public class B : A
    {
        [MyAttribute2]
        [MyAttribute3]
        public new string field;
    }
