    public class FirstClass
        {
            private SecondClass TheField { get; set; }
    
            public void SomeMethod()
            {
                TheField.Update( /*parameters*/);
            }
    
            private class SecondClass
            {
                public void Update( /*parameters*/)
                {
                    // do something
                }
            }
        }
 
