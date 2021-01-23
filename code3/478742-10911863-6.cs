    public class OtherChildViewModel
    {
        public string MyProp { get; set; }
        public OtherChildViewModel()//Dependency here with constructor injection
        {
            this.MyProp = "Other Child Viewmodel";
        }
    }
