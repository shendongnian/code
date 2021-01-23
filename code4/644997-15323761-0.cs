    public MainWindow()
    {
        Button buttonOk = new Button();
    
        buttonOk.Click += buttonOk_Click;
    }
    
    void buttonOk_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
