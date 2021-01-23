    public class Bullet : IProjectile 
    {
        public string Name { get { return "Bullet"; } }
        public string Damage { get { return 5; } }
        
        public void Fire() 
        {
            Console.WriteLine("Did {0} damage.",Damage);
        }    
    }
