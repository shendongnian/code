You can use a very useful in this case: the property Tag. You set the Tag in XAML with a binding, then check its value.
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        FrameworkElement frameworkElement = sender as FrameworkElement;
        if(sender != null)
        {
            Img tag = frameworkElement.Tag as Img;
            // You directly have the Img that correspond to the button you have clicked
        }
    }
