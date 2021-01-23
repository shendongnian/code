        class Neuro
        {
            public class Net
            {
                public void SomeMethod()
                {
                    int x = Neuro.OtherMethod(); 
                }
            }
        
            public static int OtherMethod() 
            {
                return 123;  
            }
        }
