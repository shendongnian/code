    public class A
    {
        public virtual void MethodeTest()
        {
            //will return B
            Type t = this.GetType();
            Console.WriteLine(t);
            Console.ReadLine();
        }
    }
    
    public class B:A
    {
        public int FieldTest;
    
        public override void MethodeTest()
        {
            base.MethodeTest(); // base class implementation
    
            Console.WriteLine(FieldTest); // FieldTest is available here
            Console.ReadLine();
        }
    }
