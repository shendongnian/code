    public class MyClass
    {
        public enum EType { String, Double };
        EType TypeFilled {get; private set }
        string _x;
        public string X { get { return _x; }; set { _x = value; TypeFilled = EType.String; }
        double y;
        public double y { get { return _y; }; set { _y = value; TypeFilled = EType.Double; }
    }
