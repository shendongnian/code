    public class BasketballPlayer : Player
    {
        public BasketballPlayer(string name)
            : base(name, "Basketball")
        {
        }
    
        public void Run(int distance)
        {
            Console.WriteLine("{0} just ran {1} meters.", Name, distance);
        }
    
        public bool Shoot()
        {
            Console.WriteLine("Successful shot for " + Name);
            return true;
        }
    }
