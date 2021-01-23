        [RegionMemberLifetime(KeepAlive = false)]
        [Export(ViewNames.AppView)]
        [PartCreationPolicy(CreationPolicy.Shared)] 
        public partial class AppMain : UserControl
        {
            public AppMain()
            {
                InitializeComponent();
            }
        }
