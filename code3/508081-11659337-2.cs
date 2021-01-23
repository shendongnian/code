    public class MyControl : UserControl
    {
        public SomeBehavior SomeBehavior { get; private set; }
    
        public MyControl()
        {
            SomeBehavior = new SomeBehavior();
        }
    }
