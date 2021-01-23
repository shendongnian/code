    public abstract class EAction
    {
        public abstract void DoYourDeal();
    
    
        internal static readonly ShutDownEAction  Shutdown = new ShutDownEAction() ; 
        public static readonly ReadEAction  Shutdown = new ReadEAction() ;
        //...
    }
    
        public class ReadEAction : EAction {...}
        public class WriteEAction : EAction {...}
        public class UpdateEAction : EAction {...}
        internal class ShutDownEAction : EAction {...}
    
    public void DoSomething(EAction action)
    {
        action.DoYourDeal();
    }
