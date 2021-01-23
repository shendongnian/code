        class Neuro
        {
            public class Net
            {
                public void SomeMethod()
                {
                    Neuro n = new Neuro();
                    int x = n.OtherMethod(); 
                }
            }
        
            public int OtherMethod() 
            {
                return 123;  
            }
        }
