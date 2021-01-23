    class Giraffid
    {
        public virtual void Eat(params int[] leaves)
        {
            Console.WriteLine("G");
        }
    }
    class Okapi : Giraffid
    {
        public override void Eat(int[] leaves)
        {
            Console.WriteLine("O");
        }
    }
