    public class CustomBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new MyEndPointBehavior();
        }
    
        public override Type BehaviorType
        {
            get
            {
                return typeof(MyEndPointBehavior);
            }
        }
    }
