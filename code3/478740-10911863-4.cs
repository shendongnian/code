    public class PivotViewModel
    {
        public string MyProp { get; set; }
        public ObservableCollection<string> MyList { get; set; }
        public PivotViewModel()//Dependency here with constructor injection
        {
            this.MyProp = "Test";
            this.MyList = new ObservableCollection<string>(){"Test1", "Test2"};
        }
    }
