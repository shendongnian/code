    public class X
    {
        private int _field;
    
        public void PrintField()
        {
            Console.WriteLine(_field); // prints 0
        }
    
        public void PrintLocal()
        {
            int local;
            Console.WriteLine(local); 
            // yields compiler error "Use of unassigned local variable 'local'"
        }
    }
