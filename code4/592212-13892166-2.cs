    public MainPage()
        {
            this.InitializeComponent();
            //This will cache your page and every time you navigate to this 
            //page a new page will not be created.
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
    
            this.brainPageController = new PageController();
    
            // add items from the List<String> to the listBox
            listGoals.ItemsSource = brainPageController.GetListGoals();
        }
