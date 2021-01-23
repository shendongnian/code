    public class FooDataBag : DataBagDecorator
    {
        public FooDataBag(IDataBag dataBag) 
            : base(dataBag) { }
    
        public override string UserControl
        {
            // added behavior
            get { return "Foo" + base.UserControl; }
            set { base.UserControl = value; }
        }
    
        // you don't need to override other members
    }
