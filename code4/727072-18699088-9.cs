    namespace Playground.Sandbox
    {
        using System;
        using System.ServiceModel.Configuration;
        
        public class MyBehaviorExtensionElement : BehaviorExtensionElement
        {
            protected override object CreateBehavior()
            {
                var myEndpointBehavior = new MyEndpointBehavior();
                
                return myEndpointBehavior;
            }
            
            public override Type BehaviorType
            {
                get
                {
                    return typeof(MyEndpointBehavior);
                }
            }
        }
    }
