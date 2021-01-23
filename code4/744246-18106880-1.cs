    [ViewSortHint("050")]
    [ViewExport(RegionName = RegionNames.WorkspaceTabRegion)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class AView : UserControl
    {
        public AView()
        {
            InitializeComponent();
        }
        
        [Import]
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly", Justification = "MEF requires property; never retrieved")]
        PrintingViewModel ViewModel { set { this.DataContext = value; } }
        public string ViewTitle { get { return "AView"; } }
    }
