    public sealed class FirstClass : SecondClass
    {
        public FirstClass()
        {
    
        }
    
        public void SomeMethod(int j)
        {
            base.Update(j);
        }
    }
    
    public abstract class SecondClass
    {
    
        public SecondClass() { }
    
        protected void Update(int i)
        {
            Console.WriteLine(i.ToString());
        }
    }
