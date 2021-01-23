    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
    try{
        myImage.Source = new BitmapImage(
           new Uri(@"images\Countries\dz.png",UriKind.Relative));
    }catch(Exception ex)
    {
    MessageBox.Show(ex.Message);
    }
    }
