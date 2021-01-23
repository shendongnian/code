    class ObjectParent
    {
        public virtual void sampleMethod()
        {
            Console.WriteLine("Parent");
        }
    }
    
    class ObjectChild
    {
        public override void sampleMethod()
        {
            Console.WriteLine("Child");
        }
    }
