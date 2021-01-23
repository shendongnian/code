    public class ClassA
    {
        public int I;
        public double D;
        public ClassB ClassB;
    }
    public class ClassB
    {
        public int I;
        public string S;
    }
    var jt = JToken.Parse("{ I:1, D:3.5, ClassB:{I:2, S:'test'} }");
    int i1 = jt.GetValue<int>("I");
    double d1 = jt.GetValue<double>("D");
    ClassB b = jt.GetValue<ClassB>("ClassB");
