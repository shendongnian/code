    void Main()
    {
        IEngineAction Test1 = new Test1Action();
        IEngineAction Test2 = new Test2Action();
        Test1.Execute("Test1");
        Test2.Execute("Test2");
    }
    public interface IEngineAction
    {
        void Execute(string Parameter);
    }
    public abstract class EngineAction : IEngineAction
    {
        protected abstract void PerformAction();
        protected string ForChildren;
        public void Execute(string Parameter)
        {  // Pretend this method encapsulates a 
           // lot of code you don't want to duplicate 
          ForChildren = Parameter;
          PerformAction();
        }
    }
    
    public class Test1Action : EngineAction
    {
        protected override void PerformAction()
        {
            ("Performed: " + ForChildren).Dump();
        }
    }
    public class Test2Action : EngineAction
    {
        protected override void PerformAction()
        {
            ("Actioned: " + ForChildren).Dump();
        }
    }
