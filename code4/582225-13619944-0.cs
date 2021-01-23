    class SubSubC : SubB
    {
        public object CProperty { get; private set; }
        public SubSubC(object cProperty, string bProperty, int id) : base(bProperty, id)
        {
            CProperty = cProperty;
        }
    }
    class SubB : BaseA
    {
        public string BProperty { get; private set; }
        public SubB(string bProperty, int id) : base(id)
        {
            BProperty = bProperty;
        }
    }
    class BaseA
    {
        public int ID { get; private set; }
        public BaseA(int id)
        {
            ID = id;
        }
    }
