    public abstract class Container
    {
        public abstract void Print();
    
        public List<Container> Contents { get; set; }
    }
    
    public class Box : Container
    {
        public override void Print() 
        {
            foreach (Container c in Contents)
                Console.WriteLine("I am a {0}", c.ToString());
        }
        
    }
