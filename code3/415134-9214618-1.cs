    public class ExtendedState : State  {
        public int Number2 { get; set; }
    
        public orverride void SetNumber(int n)
        { 
            base.SetNumber(n);
            Number2 = n;
        }
    }  
