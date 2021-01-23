    public class DoSomethingOptions
    {
        private Class1 class1;
        public bool HasClass1 { get; private set; }
        public Class1 Class1 
        {
            get { return class1; }
            set
            {
                class1 = value;
                HasClass1 = true;
            }
        }
        ... for other properties ...
    }
