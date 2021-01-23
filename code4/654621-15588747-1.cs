    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    		ToolTipServiceHelper ttsh = new ToolTipServiceHelper();
    		ttsh.EnumVisual(this.Content as Visual);
    	}
    }
