    public class VM1
    {
        private bool isValid;
        private VM2 vmInstance;
        //......
        public VM1(VM2 vm2)
        {
            VMInstance = vm2;
        }
        public bool IsValid
        {
            get
            {
                return this.isValid && VMInstance.IsValid;
            }
            set
            {
                // 
            }
        }
        public VM2 VMInstance 
        { 
            get { return vmInstance; }
            set { vmInstance = value; }
        }
    }
    public class VM2
    {
        public bool IsValid { get; set; }
    }
