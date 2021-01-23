        public class MyClass
        {
            //  ...
            /// <summary>
            /// The "///<summary>" convention is recognized by the IDE, which
            /// uses the text to generate context help for the member. 
            /// 
            /// As TyCobb notes below, method1 in correct C# idiom is more 
            /// likely to be a property than a method -- and the field "backing"
            /// it would be given the same name, but with the first letter 
            /// lowercased and prefixed with an underscore. 
            /// </summary>
            public int Property1
            {
                get { return _property1; }
                set { _property1 = value; }
            }
            private int _property1 = 0;
            private bool _flag1 = false;
            // Regions are a convenience. They don't affect compilation. 
            #region Public Methods
            /// <summary>
            /// Do something arbitrary
            /// </summary>
            public void Method2()
            {
            }
            #endregion Public Methods
        }
