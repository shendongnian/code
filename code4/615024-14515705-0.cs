    public class Parent
    {
        public virtual void Print()
        {
            Console.WriteLine("Print in Parent");
        }
    }
    
    public class Child : Parent
    {
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Print in Child");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
             Child c = new Child();
             //or Parent child = new Child(); 
             child.Print();  //Calls Child class method
             ((Parent)c).Print(); //Want Parent class method call
        }
    }
