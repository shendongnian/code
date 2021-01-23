    public class OtherViewModel
    {
        public string MyProp { get; set; }
        public OtherChildViewModel MyChild { get; set; }
        public OtherViewModel()
        {
            this.MyProp = "Other Viewmodel here";
            this.MyChild = new OtherChildViewModel();
        }
    }
