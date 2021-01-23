    public abstract class Computer
    {
        string Type { get; protected set; }
    }
    public class DellComputer : Computer 
    {
        public DellComputer()
        {
           this.Type = "Dell"
        }
    }
