    private void Button_Click(object sender, RoutedEventArgs e)
    {            
        if (MyButton.IsChecked == true) 
        {
            MyBorder.Visibility = System.Windows.Visibility.Visible;
        }
        if (MyButton.IsChecked == false)
        {
            MyBorder.Visibility = System.Windows.Visibility.Hidden;
        } 
    }
