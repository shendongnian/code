    public class ActionContext
    {
        public Action Action;
        public int Variable = 0;
        
       
       public Func<ActionContext> Create(Action action)
       {
            return (() => { Action = action; return this; });
       }
        
        
       public void Test()
       {
          // I don't want provide ActionContext through delegate(ActionContext)
          var context = Create(() => { Variable = 10; });
         context().Action.Invoke();
       }
        
    }
