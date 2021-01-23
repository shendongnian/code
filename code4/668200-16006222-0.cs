    public MainPage()
        {
            InitializeComponent();
            if(serviceAvailable==false)
			{
			xamlButton.IsEnabled = false;
			}
			else
			xamlButton.IsEnabled = true;
        }
