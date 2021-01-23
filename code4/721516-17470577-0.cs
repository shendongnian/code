    class Program
    {
        static void Main(string[] args)
        {
            List<Actor> MyActors = new List<Actor>();
            MyActors.Add(new Player());        
            MyActors.Add(new Enemy());        
            MyActors.Add(new Player());
            foreach (var Actor in MyActors)
            {
                Actor.DoSomething();
            }
        }
    }
    public abstract class Actor
    {
        public string Name;
        public virtual void DoSomething()
        {
            Console.WriteLine("Actor does something");
        }
    }
    public class Player : Actor
    {
        public override void DoSomething()
        {
            Console.WriteLine("Player does something");
        }        
    }
    public class Enemy : Actor
    {
        public override void DoSomething()
        {
            Console.WriteLine("Enemy does something");
        }       
    }
