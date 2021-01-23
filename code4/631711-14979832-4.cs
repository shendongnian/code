    public partial class MyControl : UserControl
    {
        public TwoStrings TsObj { get; set; }
        public MyControl()
        {
          InitializeComponent();
          
          this.DataContext = TsObj = new TwoStrings();
        }
    }
