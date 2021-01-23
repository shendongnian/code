    // using statements, other components you use in your class
    using System;
    // namespace name (a group so to speak)
    namespace NamespaceName {
        // class, this gets nested under a namespace
        public class MyClass {
            // private variables
            private int myVariable;
            // constructors
            public MyClass() {
                // this is where you create the instance, set variables and stuff
                myVariable = 314;
            }
            // methods
            public void DoSomething() {
                ++myVariable;
            }
            private void anotherMethod() { }
        }
    }
