    public MainWindow MainWindow { get; set; }    
    private void ButtonBack_Click(object sender, RoutedEventArgs e)
    {
        this.Visible = false;
        MainWindow.Visible = true;
    }
