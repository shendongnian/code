    interface ICollidable
    {
        void Accept(IVisitor other);
    }
    interface IVisitor
    {
        void VisitAsteroid(Asteroid a);
        void VisitSpaceship(Spaceship s);
    }
    class Asteroid : ICollidable, IVisitor
    {
        public void Accept(IVisitor other)
        {
            Console.Write("[Asteroid] ");
            other.VisitAsteroid(this);
        }
        public void VisitAsteroid(Asteroid a)
        {
            Console.WriteLine("Collided with asteroid");
        }
        public void VisitSpaceship(Spaceship s)
        {
            Console.WriteLine("Collided with asteroid");
        }
    }
    class Spaceship : ICollidable, IVisitor
    {
        public void Accept(IVisitor other)
        {
            Console.Write("[Spaceship] ");
            other.VisitSpaceship(this);
        }
        public void VisitAsteroid(Asteroid a)
        {
            Console.WriteLine("Collided with spaceship");
        }
        public void VisitSpaceship(Spaceship s)
        {
            Console.WriteLine("Collided with spaceship");
        }
    }
    class Main
    {
        public static void Main(string[] args)
        {
            Asteroid a1 = new Asteroid();
            Asteroid a2 = new Asteroid();
            Spaceship s1 = new Spaceship();
            Spaceship s2 = new Spaceship();
            s1.Accept(a1);
            s1.Accept(as);
            a1.Accept(s1);
            a2.Accept(a2);
        }
    }
