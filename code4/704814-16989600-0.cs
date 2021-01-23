    public sealed class FirstClass:SecondClass
        {
            public FirstClass()
            {
                
            }
    
            protected override void Update(int i)
            {
                base.Update(i);
            }
    
            public void SomeMethod(int j)
            {
                this.Update(j);
            }
        }
        
        public abstract class SecondClass
        {
    
            public SecondClass() { }
    
            protected virtual void Update(int i)
            {
                Console.WriteLine(i.ToString());
            }
        }
