    public abstract class Computer
    {
        public virtual string Type { get; }
    }
    public class DellComputer : Computer 
    {
        public override string Type 
        {
            get {
               return "Dell";
            }
        }
    }
