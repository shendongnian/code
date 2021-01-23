    private void CommonClickHandler(object sender, MouseButtonEventArgs e)
    {
        Image picture = e.OriginalSource as Image;  //OriginalSource is the original element
        if (picture != null)
            picture.Visibility = Visibility.Collapsed;
    }
