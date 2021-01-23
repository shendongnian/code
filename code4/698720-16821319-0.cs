        public class MyClass {
            //  ...
            /// <summary>
            /// This method assigns an arbitrary number to an unused field. 
            /// The "///" convention is recognized by the IDE, which uses the 
            /// text to generate context help for the member. 
            /// </summary>
            public void method1(int n)
            {
                field = n;
            }
            private int field = 0;
        }
