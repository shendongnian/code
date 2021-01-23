    public class SubmitActionProvider:ActionProvider
    {        
        public override Func<bool>  IsActionVisible
        {
	         get 
	         { 
	            Console.WriteLine("submit");
                      return null;
	         }
        }
    }
    public class CancelActionProvider : ActionProvider
    {
        public override Func<bool> IsActionVisible
        {
            get
            {
                Console.WriteLine("cancel");
                return null;
            }
        }
    }
    public class ActionProvider
    {
        public virtual Func<bool> IsActionVisible { get { Console.WriteLine("Default implementation"); return null; } }
        public virtual Func<bool> IsActionEnabled { set { } }
    }
