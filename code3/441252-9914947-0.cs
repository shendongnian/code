    class B : A
    {
        public sealed override void methodB()
        {
            Console.WriteLine("Class C cannot override this method now");
        }
    }
