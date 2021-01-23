    class TempData
    {
        public string Contract { get; set; }
        public string ProjectName { get; set; }
    }
    
    public sealed partial class BlankPage2 : Page
    {
        public BlankPage2()
        {
            this.InitializeComponent();
            string contract = "contract", project = "project";
            TempData t = new TempData();
            t.Contract = contract;
            t.ProjectName = project;
            this.DataContext = t;
        }
    }
