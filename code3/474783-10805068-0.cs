        [System.AttributeUsage(System.AttributeTargets.Class)]
        public class BaseClassLinkAttribute : System.Attribute
        {
            public System.Type LinkedType { get; set; }
            public BaseClassLinkAttribute(Type linkedType)
            {
                // Probably wat to make sure type is derrived from BaseClass
                LinkedType = linkedType;
            }
        }
