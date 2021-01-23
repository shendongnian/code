        [Export(ViewNames.AppView)]
        [PartCreationPolicy(CreationPolicy.Shared)] 
        public partial class AppMain : UserControl, IRegionMemberLifetime
        {
            public AppMain()
            {
                InitializeComponent();
            }
            public bool KeepAlive
            {
                get { return false; }
            }
        }
