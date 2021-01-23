    string AppPath = Directory.GetCurrentDirectory();
    public MainWindow()
    {
    	InitializeComponent();
    	ImgShowHide.Source = new BitmapImage(new Uri(AppPath + "\\img\\clip.jpg"));
    }
    private void ImgShowHide_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
    	HidePassword();
    }
    
    private void ImgShowHide_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
    	ShowPassword();
    }
    private void ImgShowHide_MouseLeave(object sender, MouseEventArgs e)
    {
    	HidePassword();
    }
    private void txtPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
    {
    	if(txtPasswordbox.Password.Length > 0)
    		ImgShowHide.Visibility = Visibility.Visible;
    	else
    		ImgShowHide.Visibility = Visibility.Hidden;
    }
    
    void ShowPassword()
    {
    	ImgShowHide.Source = new BitmapImage(new Uri(AppPath + "\\img\\cus.jpg"));
    	txtVisiblePasswordbox.Visibility = Visibility.Visible;
    	txtPasswordbox.Visibility = Visibility.Hidden;
    	txtVisiblePasswordbox.Text = txtPasswordbox.Password;
    }
    void HidePassword()
    {
    	ImgShowHide.Source = new BitmapImage(new Uri(AppPath + "\\img\\clip.jpg"));
    	txtVisiblePasswordbox.Visibility = Visibility.Hidden;
    	txtPasswordbox.Visibility = Visibility.Visible;
    	txtPasswordbox.Focus();
    }
