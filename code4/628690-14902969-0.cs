    public partial class SystemControls : UserControl, ISystemControls
    {
        IDriver _Driver;
        SystemControls_VM _VM;
            public SystemControls(IDriver InDriver, SystemControls_VM InVM)
            {
                _VM = InVM;
                _Driver = InDriver;
                DataContext = InVM;//new SystemControls_VM(_Driver);
                InitializeComponent();
            }
