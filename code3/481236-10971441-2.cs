    public void InitializeComponent() {
        ...
        System.Windows.Application.LoadComponent(this, new System.Uri("/SilverlightApp1;component/MainPage.xaml", System.UriKind.Relative));
        this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
    }
