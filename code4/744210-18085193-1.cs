    class Foo {
        // Properies are PascalCase
        public int SomeProperty { get; set; }
    
        // *Private* fields are lowerCamelCase
        private int aField;
        // By some conventions (I use these)
        private int m_anotherField;            // "m_" for "member"
        private static object s_staticLock;    // "s_" for "static"
        // *Public* fields are PascalCase
        public int DontUsePublicFields;        // In general, don't use these
        public const int ConstantNumber = 42;
   
        // Methods are UpperCase
        // Parameters and variables are lowerCase
        public SomeMethod(int myParameter) {
            int[] localVariable;
            
            //string names[] = {};     // Not valid C#! 
            string[] names = new string[] { "Jack", "Jill" };
        }
    }
