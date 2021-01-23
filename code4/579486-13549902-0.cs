    protected string Uri { get; set; }
    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        animation1.Stop();
        animation2.Stop();
        animation1.Begin();
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {          
        this.Uri = "/fooApp;component/Page2.xaml?id=1";
        animation2.Begin();                       
    }
    private void button2_Click(object sender, RoutedEventArgs e)
    {
        this.Uri = "/fooApp;component/Page2.xaml?id=2";
        animation2.Begin();          
    }
    private void button3_Click(object sender, RoutedEventArgs e)
    {
        this.Uri = "/fooApp;component/Page2.xaml?id=3";
        animation2.Begin();              
    }
    private void Storyboard_Completed(object sender, EventArgs e)
    {
        this.NavigationService.Navigate(new Uri(this.Uri, UriKind.Relative));      
    }
