    class MainWindow
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    	}
    	void OpenSettingsWindow()
    	{
    		var dlg = new SettingsWindow();
    		dlg.DataContext = mGlobalSettings;
    		dlg.ShowDialog();
    	}
    	
    	MySettings mGlobalSettings = new MySettings();
    }
