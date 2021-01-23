    public class BaseClass
    {
        private bool keyboardOn;
    
        protected bool KeyboardOn;
        {
            get
            {
                return this.keyboardOn;
            }
            set
            {
                this.keyboardOn = value;
            }
        }    
    }    
    
    public class InheritFromBase : BaseClass
    {
        ....
    
        if(this.KeyboardOn)
        {
            // do something based on base property
        }
    
        ....
    }
