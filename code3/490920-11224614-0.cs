	public MainWindow()
		{
			InitializeComponent();
			if( System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
			{
				MyCustomObjects = new List<object>();
				MyCustomObjects.Add("Hello");
			}
        }
