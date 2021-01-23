    namespace SO
    {
        class PresentingAttribute : Attribute
        {
        }
        class FnVM
        {
            public int numA { get; set; }
            public int numB { get; set; }
            public IEnumerable<MethodInfo> Actions
            {
                get
                {
                    return typeof( FnVM ).GetMethods().Where( minfo => 
                        minfo.GetCustomAttribute( typeof( PresentingAttribute ) ) != null
                    );
                }
            }
            [Presenting]
            public int AddFunction( )
            {
                return numA + numB;
            }
            [Presenting]
            public int MulFunction( )
            {
                return numA * numB;
            }
        }
    }
