    Using these two classes as examples:
    
    public class Parent
    {
        public void NonVirtual()
        {
            Console.WriteLine("Nonvirtual - Parent");
        }
        public virtual void Virtual()
        {
            Console.WriteLine("Virtual - Parent");
        }
    }
    
    public class Child : Parent
    {
        public override void Virtual()
        {
            Console.WriteLine("Virtual - Child");
        }
    
        public void NonVirtual()
        {
            Console.WriteLine("Nonvirtual - Child");
        }
    }
