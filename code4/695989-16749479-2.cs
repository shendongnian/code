    private void Image_MouseLeave(object sender, MouseEventArgs e)
    {
       var img = sender as Image;
       img.Source = (ImageSource)img.FindResource("ImgBtnLightbulbOff");
    }
    
    private void Image_MouseEnter(object sender, MouseEventArgs e)
    {
       var img = sender as Image;
       img.Source = (ImageSource)img.FindResource("ImgBtnLightbulbOn");
    }
