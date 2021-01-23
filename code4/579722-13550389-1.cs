    namespace SO.Weston.WpfStaticPropertyBinding
    {
        public sealed class StaticAccessClass
        {
            public string TheStaticProperty
            {
                get { return TheStaticClass.TheStaticProperty; }
            }
        }
    }
    
