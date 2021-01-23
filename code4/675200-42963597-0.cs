     public partial class SampleClass: UserControl
    {
        public SampleClass()
        {
            ScenarioHeight = System.Windows.SystemParameters.WorkArea.Height - 350;
            InitializeComponent();           
           
            
        }
        public double ScenarioHeight  { get;set;}
