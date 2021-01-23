    public delegate Widget StepOneActionDelegate(Widget widget);
    
    public class Worker
    {
    
        public StepOneActionDelegate StepOneAction { get; set; }
    
        public Worker()
        {
            StepOneAction = RealStepOne;
        }
        
        public void DoSomeWork()
        {
            Widget widget = new Widget();
            Widget newWidget = StepOneAction(widget);
            // more steps here
        }
        
        private Widget RealStepOne(Widget widget)
        {
            // Do some real work here
            return widget;
        }
    }
