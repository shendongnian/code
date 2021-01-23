    public class VM1
    {
        // ...
        public bool IsValid
        {
            get
            { 
                return isValid && 
                       (VMInstance != null && VMInstance.IsValid);
            }
            set
            {
                isValid = value;
            }
        }
        // ...
    }
