    public abstract class Computer
    {
        public virtual string Type { get; }
    }
    
    public class DellComputer : Computer 
    {
        public override string Type 
        {
            get { return "Dell"; }
        }
    }
        
    public class HpComputer : Computer 
    {
        public override string Type 
        {
            get { return "HP"; }
        }
    }
    
    // Here I'm using an enum to indicate the type desired.  You might use a string
    // or anything else that makes sense in your problem domain.
    
    public enum ComputerType
    {
        Dell = 1,
        Hp = 2
    }
    
    public class ComputerFactory
    {
        public Computer Create(ComputerType type)
        {
            switch (type)
            {
                case ComputerType.Dell:
                    return new DellComputer();
                case ComputerType.Hp:
                    return new HpComputer();
                default:
                    throw new InvalidArgumentException();
            }
        }
    }
    
    // Usage would be something like:
    
    
    List<Computer> computers = new List<Computer>();
    computers.Add(ComputerFactory.Create(ComputerTypes.Dell);
    computers.Add(ComputerFactory.Create(ComputerTypes.Dell);
    computers.Add(ComputerFactory.Create(ComputerTypes.Hp);
