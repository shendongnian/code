    public class A
    {
        public string GetData() { return "A";}
    }
    public class B : A
    {
        public new string GetData() { return "B"; }
    }
