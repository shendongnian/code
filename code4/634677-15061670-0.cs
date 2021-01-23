    public class HumanProperties
    {
        public int Prop1
        {
            get { return _prop1; }
            set { _prop1 = value; }
        }
        private int _prop1 = 0;
        public int Prop2
        {
            get { return _prop2; }
            set { _prop2 = value; }
        }
        private int _prop2;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _name = String.Empty;
    }
    public class Human
    {
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        private int _age = 0;
        public HumanProperties Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }
        private HumanProperties _properties = new HumanProperties();
    }
