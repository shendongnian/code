    protected void checkBox1_Unchecked(object sender, RoutedEventArgs e)
     {
         grid1.Visibility = System.Windows.Visibility.Hidden;
     }
 
    protected void checkBox1_Checked(object sender, RoutedEventArgs e)
      {
         grid1.Visibility = System.Windows.Visibility.Visible; 
      }
