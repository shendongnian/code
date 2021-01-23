    class Program
    {
        static void Main(string[] args)
        {
            Test2 t = new Test2();
            t.display();
            t.absDsisplay();
        }
    }
    abstract class Test1
    {
        public void display()
        {
            Console.WriteLine("display");
        }
        public abstract void absDsisplay();
        
    }
    class Test2 : Test1
    {
        
        void GetValu()
        {
          
        }
        public override void absDsisplay()
        {
            Console.WriteLine("absDisplay");
        }
    }
