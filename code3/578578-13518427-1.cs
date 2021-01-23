    public abstract class Command
    {
        public abstract object execute();
    }
    
    public abstract Binary : Command
    {
        //the execute object is inherited from the command class.
    }
    
    public class Multiply : Binary
    {
        public override execute()
        {
            //do stuff
        }
    }
