    public class SomeBehavior
    {
        public List<MyObject> Sample
        {
            get { return Session["MyObject"] as List<MyObject>; }
            set { Session["MyObject"] = value; }
        }
    }
    public class MyControl : UserControl
    {
        private SomeBehavior _someBehavior;
        public MyControl()
        {
            _someBehavior = new SomeBehavior();
        }
        public List<MyObject> Sample
        {
            get { return _someBehavior.Sample; }
            set { _someBehavior.Sample = value; }
        }   
    }
