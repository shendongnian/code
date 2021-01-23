    public interface IContainable { }
    
    public abstract class Container
    {
        public virtual void Print() 
        {
            foreach (IContainable c in Contents)
                Console.WriteLine("I am a {0}", c.ToString());
        }
    
        public List<IContainable> Contents { get; set; }
    }
    
    public class Pallet : Container {  }
    
    public class Box : Container, IContainable {  }
    
    public class Item : IContainable { }
