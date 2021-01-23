    class ObjectParent
    {
        public virtual void sampleMethod()
        {
            Console.WriteLine("Parent");
        }
    }
    
    class ObjectChild : ObjectParent
    {
        public override void sampleMethod()
        {
            Console.WriteLine("Child");
        }
    }
