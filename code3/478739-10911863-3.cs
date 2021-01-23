    public class MainViewModel
    {
        public string MyProp { get; set; }
        public PivotViewModel MyPivot { get; set; }
        public OtherViewModel MyOther { get; set; }
        public MainViewModel()
        {
            this.MyProp = "Main VM";
            this.MyPivot = new PivotViewModel();
            this.MyOther = new OtherViewModel();
        }
    }
