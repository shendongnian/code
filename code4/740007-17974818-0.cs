    public class Foo
    {
        private string x;
    
        public Foo(string x)
        {
            // x = x;      Assigns local parameter x to x, not what we want
            this.x = x; // Assigns instance variable x to local parameter x: this disambiguates between the two.
        }
    }
