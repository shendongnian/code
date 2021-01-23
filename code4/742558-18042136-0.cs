    public partial class MainWindow : Window
    {
    	private bool _continue = false;
    	
    	public MainWindow()
    	{
    		InitializeComponent();
    
    		worker.WorkerSupportsCancellation = true;
    		worker.DoWork += delegate 
    		{
    			Hello();
    		};
    	}
    
    	BackgroundWorker worker = new BackgroundWorker();
    
    	private void startWrite(object sender, RoutedEventArgs e)
    	{
    		startButton.IsEnabled = false;
    		stopButton.IsEnabled = true;
    		_continue = true;
    		worker.RunWorkerAsync();
    	}
    
    	private void stopWrite(object sender, RoutedEventArgs e)
    	{
    		worker.CancelAsync();
    		startButton.IsEnabled = true;
    		stopButton.IsEnabled = false;
    		_continue = false;
    	}
    
    	public void Hello()
    	{
    		while (_continue)
    		{
    			Application.Current.Dispatcher.Invoke((Action)(() =>
    			{
    				HelloText.AppendText("Hello World!\n");
    			}));                
    		}
    	}
    }
