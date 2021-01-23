    public MainPage()
    {
      this.InitializeComponent();
      this.WaitForFiveSeconds();
    }
    
    private async void WaitForFiveSeconds()
    {
      await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(5));
      // do something after 5 seconds!
    }
