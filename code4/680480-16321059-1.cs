        public class Neuro  // Neuro has to be public in order to have a public class inherit from it.
        {
            public static int OtherMethod() 
            {
                return 123;  
            }
        }
        public class Net : Neuro
        {
            public void SomeMethod()
            {
                int x = OtherMethod(); 
            }
        }
