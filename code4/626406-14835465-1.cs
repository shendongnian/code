    public class VM1
    {
        // ...
        public bool IsValid
        {
            get
            { 
                return this.isValid && 
                       (this.VMInstance != null && this.VMInstance.IsValid);
            }
            set
            {
                this.isValid = value;
            }
        }
        // ...
    }
