    public abstract class Command
    {
        public abstract object execute();
    }
    
    public abstract class Binary : Command
    {
        //the execute object is inherited from the command class.
    }
    
    public class Multiply : Binary
    {
        public override object execute()
        {
            //do stuff
        }
    }
