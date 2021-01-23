    private void Image_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Image i = sender as Image; ;
        BitmapImage b = new BitmapImage(new Uri(@"pack://application:,,,/" 
             + Assembly.GetExecutingAssembly().GetName().Name 
             + ";component/" 
             + "Images/1.jpg", UriKind.Absolute)); 
        i.Source=b;
    }
