    public class State 
    { 
        public int Number { get; set; } 
    
        public virtual void SetNumber(int n)
        { 
            Number = n;
        }
    
        public void Execute(IAction action) 
        { 
            if (action.IsValid(this)) 
                action.Apply(this); 
        }             
    } 
