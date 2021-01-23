    using System.Linq;
    using System.ServiceModel.Configuration;
    using System.Web;
    
    namespace MyCustomExtensionService
    {
        public class MyBehaviorSection : BehaviorExtensionElement
        {
    
            protected override object CreateBehavior()
            {
                return new MyCustomAttributeBehavior();
    
            }
    
            public override Type BehaviorType
            {
    
                get { return typeof(MyCustomAttributeBehavior); }
    
    
            }
        }
    }
