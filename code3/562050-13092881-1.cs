    public abstract class Computer
    {
        public string Type { get; protected set; }
    }
    public class DellComputer : Computer 
    {
        public DellComputer()
        {
           this.Type = "Dell"
        }
    }
